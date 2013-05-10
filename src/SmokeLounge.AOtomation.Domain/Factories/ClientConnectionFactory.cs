// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientConnectionFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ClientConnectionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Hook;
    using SmokeLounge.AOtomation.Hook.Communication.NamedPipe;

    [Export(typeof(IClientConnectionFactory))]
    public class ClientConnectionFactory : IClientConnectionFactory
    {
        #region Fields

        private readonly IIpcServerChannelFactory ipcServerChannelFactory;

        private readonly IReadProcessMemory readProcessMemory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ClientConnectionFactory(
            IIpcServerChannelFactory ipcServerChannelFactory, IReadProcessMemory readProcessMemory)
        {
            Contract.Requires<ArgumentNullException>(ipcServerChannelFactory != null);
            Contract.Requires<ArgumentNullException>(readProcessMemory != null);
            this.ipcServerChannelFactory = ipcServerChannelFactory;
            this.readProcessMemory = readProcessMemory;
        }

        #endregion

        #region Public Methods and Operators

        public IClientConnection Create(int remoteProcessId, IntPtr remoteProcessHandle)
        {
            var sendHookCallbackChannelName = "AnarchyHook" + remoteProcessId + "cs";
            var sendHookCallbackChannel = this.ipcServerChannelFactory.Create(sendHookCallbackChannelName);
            var receiveHookCallbackChannelName = "AnarchyHook" + remoteProcessId + "dm";
            var receiveHookCallbackChannel = this.ipcServerChannelFactory.Create(receiveHookCallbackChannelName);
            var hookServerChannelName = "AnarchyHook" + remoteProcessId;
            return new ClientConnection(
                remoteProcessHandle, 
                hookServerChannelName, 
                sendHookCallbackChannel, 
                receiveHookCallbackChannel, 
                this.readProcessMemory);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.ipcServerChannelFactory != null);
            Contract.Invariant(this.readProcessMemory != null);
        }

        #endregion
    }
}