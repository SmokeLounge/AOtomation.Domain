// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Process.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Process type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;

    public abstract class Process : IProcess
    {
        #region Fields

        private readonly IBus bus;

        private readonly Guid id = Guid.NewGuid();

        private readonly IChainTriggerHandlers triggerHandler;

        private readonly List<ITrigger> triggers;

        private IActionExecutionContext actionExecutionContext;

        private IClient client;

        private IPlayer player;

        #endregion

        #region Constructors and Destructors

        protected Process(IChainTriggerHandlers triggerHandler, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(triggerHandler != null);
            Contract.Requires<ArgumentNullException>(bus != null);
            this.triggerHandler = triggerHandler;
            this.bus = bus;

            this.triggers = new List<ITrigger>();
        }

        #endregion

        #region Public Properties

        public bool Connected { get; private set; }

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public IPlayer Player
        {
            get
            {
                return this.player;
            }
        }

        public IReadOnlyCollection<ITrigger> Triggers
        {
            get
            {
                return this.triggers;
            }
        }

        #endregion

        #region Properties

        protected IClient Client
        {
            get
            {
                return this.client;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddTrigger(ITrigger trigger)
        {
            this.triggers.Add(trigger);
            this.bus.Publish(new MessageTriggerAddedToRemoteProcessEvent(this.Id, trigger.Id));
        }

        public void AttachClient(IClient client)
        {
            this.client = client;
            this.client.SendCallback = this.OnSendCallback;
            this.client.ReceiveCallback = this.OnReceiveCallback;
            this.actionExecutionContext = this.triggerHandler.CreateContext(this);
            this.bus.Publish(new ClientAttachedToProcessEvent(this.Id, this.client.Id));
            this.Start();
        }

        public void Send(MessageBody message)
        {
            if (this.client == null)
            {
                return;
            }

            var clientId = this.player != null ? this.player.RemoteId : Identity.None;
            this.client.Send(clientId, message);
        }

        public void SetPlayer(IPlayer player)
        {
            this.player = player;
            this.bus.Publish(new ProcessPlayerChangedEvent(this.Id, this.player.Id));
        }

        #endregion

        #region Methods

        protected virtual void Start()
        {
            if (this.client == null)
            {
                throw new InvalidOperationException();
            }

            this.client.Start();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.triggerHandler != null);
            Contract.Invariant(this.bus != null);
            Contract.Invariant(this.triggers != null);
        }

        private void OnReceiveCallback(Message message, byte[] packet, Action resumeHook)
        {
            Contract.Requires(packet != null);
            Contract.Requires(resumeHook != null);
            Contract.Requires(this.client != null);
            Contract.Requires(this.actionExecutionContext != null);

            this.bus.Publish(new PacketReceivedEvent(this.id, packet));

            if (message == null || message.Body == null)
            {
                return;
            }

            this.triggerHandler.ExecuteTriggerActions(message.Body, resumeHook, this.actionExecutionContext);
        }

        private void OnSendCallback(Message message, byte[] packet, Action resumeHook)
        {
            Contract.Requires(packet != null);
            Contract.Requires(resumeHook != null);
            Contract.Requires(this.client != null);
            Contract.Requires(this.actionExecutionContext != null);

            if (message == null || message.Body == null)
            {
                this.bus.Publish(new PacketSentEvent(this.id, packet));
                return;
            }

            this.triggerHandler.ExecuteTriggerActions(message.Body, resumeHook, this.actionExecutionContext);
            this.bus.Publish(new PacketSentEvent(this.id, packet));
        }

        #endregion
    }
}