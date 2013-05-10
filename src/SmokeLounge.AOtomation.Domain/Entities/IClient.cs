// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClient.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IClientContract))]
    public interface IClient
    {
        #region Public Properties

        Guid Id { get; }

        Action<MessageBody, Action> ReceiveCallback { get; set; }

        Action<MessageBody, Action> SendCallback { get; set; }

        #endregion

        #region Public Methods and Operators

        void Send(Identity clientId, MessageBody message);

        void Send(byte[] message);

        void Start();

        #endregion
    }

    [ContractClassFor(typeof(IClient))]
    internal abstract class IClientContract : IClient
    {
        #region Public Properties

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Action<MessageBody, Action> ReceiveCallback { get; set; }

        public Action<MessageBody, Action> SendCallback { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Send(Identity clientId, MessageBody message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        public void Send(byte[] message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}