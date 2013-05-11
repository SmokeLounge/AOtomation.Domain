// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachClientToRemoteProcessCommandHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AttachClientToRemoteProcessCommandHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.CommandHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Factories;
    using SmokeLounge.AOtomation.Domain.Infrastructure;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;
    using SmokeLounge.AOtomation.Domain.Repositories;

    [ExportCommandHandler(typeof(AttachClientToRemoteProcessCommand))]
    public class AttachClientToRemoteProcessCommandHandler : ICommandHandler<AttachClientToRemoteProcessCommand>
    {
        #region Fields

        private readonly IClientFactory clientFactory;

        private readonly IRemoteProcessRepository remoteProcessRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public AttachClientToRemoteProcessCommandHandler(
            IClientFactory clientFactory, IRemoteProcessRepository remoteProcessRepository)
        {
            Contract.Requires<ArgumentNullException>(clientFactory != null);
            Contract.Requires<ArgumentNullException>(remoteProcessRepository != null);

            this.clientFactory = clientFactory;
            this.remoteProcessRepository = remoteProcessRepository;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(AttachClientToRemoteProcessCommand command)
        {
            var remoteProcess = this.remoteProcessRepository.Get(command.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }

            var client = this.clientFactory.Create(remoteProcess.RemoteId);
            remoteProcess.AttachClient(client);
        }

        public void Handle(ICommand command)
        {
            this.Handle((AttachClientToRemoteProcessCommand)command);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.clientFactory != null);
            Contract.Invariant(this.remoteProcessRepository != null);
        }

        #endregion
    }
}