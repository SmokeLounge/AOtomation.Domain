// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ClientFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Domain.Interoperability;

    [Export(typeof(IClientFactory))]
    public class ClientFactory : IClientFactory
    {
        #region Fields

        private readonly IClientConnectionFactory clientConnectionFactory;

        private readonly IMessageSerializer messageSerializer;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ClientFactory(IClientConnectionFactory clientConnectionFactory, IMessageSerializer messageSerializer)
        {
            Contract.Requires<ArgumentNullException>(clientConnectionFactory != null);
            Contract.Requires<ArgumentNullException>(messageSerializer != null);
            this.clientConnectionFactory = clientConnectionFactory;
            this.messageSerializer = messageSerializer;
        }

        #endregion

        #region Public Methods and Operators

        public IClient Create(int remoteProcessId, IntPtr remoteProcessHandle, IntPtr serverId)
        {
            var clientConnection = this.clientConnectionFactory.Create(remoteProcessId, remoteProcessHandle);
            return new Client(clientConnection, this.messageSerializer);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.clientConnectionFactory != null);
            Contract.Invariant(this.messageSerializer != null);
        }

        #endregion
    }
}