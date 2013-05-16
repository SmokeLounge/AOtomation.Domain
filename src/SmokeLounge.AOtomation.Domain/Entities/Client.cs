// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Client type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Text;

    using SmokeLounge.AOtomation.Domain.Interoperability;
    using SmokeLounge.AOtomation.Hook;
    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;

    public sealed class Client : IClient
    {
        #region Fields

        private readonly IClientConnection clientConnection;

        private readonly Guid id = Guid.NewGuid();

        private readonly IMessageSerializer messageSerializer;

        #endregion

        #region Constructors and Destructors

        public Client(IClientConnection clientConnection, IMessageSerializer messageSerializer)
        {
            Contract.Requires<ArgumentNullException>(clientConnection != null);
            Contract.Requires<ArgumentNullException>(messageSerializer != null);
            this.clientConnection = clientConnection;
            this.messageSerializer = messageSerializer;
        }

        #endregion

        #region Public Properties

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public Action<Message, byte[], Action> ReceiveCallback { get; set; }

        public Action<Message, byte[], Action> SendCallback { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Dispose()
        {
            var disposable = this.clientConnection as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        public void Send(Identity clientId, MessageBody message)
        {
            var memoryStream = new MemoryStream();
            var n3Message = message as N3Message;
            if (n3Message != null)
            {
                n3Message.Identity = clientId;
            }

            var header = new Header { PacketType = message.PacketType, Receiver = 2, Sender = clientId.Instance };
            var envelope = new Message { Header = header, Body = message };

            this.messageSerializer.Serialize(memoryStream, envelope);
            var packet = memoryStream.ToArray();
            this.Send(packet);
            if (this.SendCallback == null)
            {
                return;
            }

            this.SendCallback(envelope, packet, () => { });
        }

        public void Send(byte[] message)
        {
            this.clientConnection.Send(message);
        }

        public void Start()
        {
            this.clientConnection.SendCallback = this.OnSendCallback;
            this.clientConnection.ReceiveCallback = this.OnReceiveCallback;
            this.clientConnection.Start();
            this.clientConnection.Send(Encoding.ASCII.GetBytes("hai!"));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.clientConnection != null);
            Contract.Invariant(this.messageSerializer != null);
        }

        private void OnReceiveCallback(byte[] packet, Action resumeHook)
        {
            Contract.Assume(resumeHook != null);
            if (this.ReceiveCallback == null)
            {
                resumeHook();
                return;
            }

            if (packet == null || packet.Length < 16)
            {
                resumeHook();
                return;
            }

            var message = this.messageSerializer.Deserialize(new MemoryStream(packet));
            Contract.Assume(this.ReceiveCallback != null);
            this.ReceiveCallback(message, packet, resumeHook);
        }

        private void OnSendCallback(byte[] packet, Action resumeHook)
        {
            Contract.Assume(resumeHook != null);
            if (this.SendCallback == null)
            {
                resumeHook();
                return;
            }

            if (packet == null || packet.Length < 16)
            {
                resumeHook();
                return;
            }

            var message = this.messageSerializer.Deserialize(new MemoryStream(packet));
            Contract.Assume(this.SendCallback != null);
            this.SendCallback(message, packet, resumeHook);
        }

        #endregion
    }
}