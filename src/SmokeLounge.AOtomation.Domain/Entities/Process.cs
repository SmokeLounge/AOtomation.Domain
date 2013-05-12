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

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;

    public abstract class Process : IProcess
    {
        #region Fields

        private readonly IDomainEventAggregator events;

        private readonly Guid id = Guid.NewGuid();

        private readonly IChainTriggerHandlers triggerHandler;

        private readonly List<ITrigger> triggers;

        private IActionExecutionContext actionExecutionContext;

        private IClient client;

        private IPlayer player;

        #endregion

        #region Constructors and Destructors

        protected Process(IChainTriggerHandlers triggerHandler, IDomainEventAggregator events)
        {
            Contract.Requires<ArgumentNullException>(triggerHandler != null);
            Contract.Requires<ArgumentNullException>(events != null);
            this.triggerHandler = triggerHandler;
            this.events = events;

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
            this.events.Publish(new MessageTriggerAddedToRemoteProcessEvent(this.Id, trigger.Id));
        }

        public void AttachClient(IClient client)
        {
            this.client = client;
            this.client.SendCallback = this.OnSendCallback;
            this.client.ReceiveCallback = this.OnReceiveCallback;
            this.actionExecutionContext = this.triggerHandler.CreateContext(this);
            this.events.Publish(new ClientAttachedToProcessEvent(this.Id, this.client.Id));
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
            this.events.Publish(new PlayerForRemoteProcessFoundEvent(this.Id, this.player.Id));
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
            Contract.Invariant(this.events != null);
            Contract.Invariant(this.triggers != null);
        }

        private void OnReceiveCallback(MessageBody message, Action resumeHook)
        {
            Contract.Requires(message != null);
            Contract.Requires(resumeHook != null);
            Contract.Requires(this.client != null);
            Contract.Requires(this.actionExecutionContext != null);

            this.triggerHandler.ExecuteTriggerActions(message, resumeHook, this.actionExecutionContext);
        }

        private void OnSendCallback(MessageBody message, Action resumeHook)
        {
            Contract.Requires(message != null);
            Contract.Requires(resumeHook != null);
            Contract.Requires(this.client != null);
            Contract.Requires(this.actionExecutionContext != null);

            this.triggerHandler.ExecuteTriggerActions(message, resumeHook, this.actionExecutionContext);
        }

        #endregion
    }
}