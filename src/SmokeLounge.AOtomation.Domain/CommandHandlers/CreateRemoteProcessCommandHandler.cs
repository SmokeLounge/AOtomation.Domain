// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateRemoteProcessCommandHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CreateRemoteProcessCommandHandler type.
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
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOtomation.Domain.Repositories;
    using SmokeLounge.AOtomation.Hook;

    [ExportCommandHandler(typeof(CreateRemoteProcessCommand))]
    public class CreateRemoteProcessCommandHandler : ICommandHandler<CreateRemoteProcessCommand>
    {
        #region Fields

        private readonly IDomainEventAggregator events;

        private readonly IRemoteProcessFactory remoteProcessFactory;

        private readonly IRemoteProcessRepository remoteProcessRepository;

        private readonly IWin32ProcessRepository win32ProcessRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public CreateRemoteProcessCommandHandler(
            IDomainEventAggregator events, 
            IWin32ProcessRepository win32ProcessRepository, 
            IRemoteProcessFactory remoteProcessFactory, 
            IRemoteProcessRepository remoteProcessRepository)
        {
            Contract.Requires<ArgumentNullException>(events != null);
            Contract.Requires<ArgumentNullException>(win32ProcessRepository != null);
            Contract.Requires<ArgumentNullException>(remoteProcessFactory != null);
            Contract.Requires<ArgumentNullException>(remoteProcessRepository != null);
            this.events = events;
            this.win32ProcessRepository = win32ProcessRepository;
            this.remoteProcessFactory = remoteProcessFactory;
            this.remoteProcessRepository = remoteProcessRepository;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(CreateRemoteProcessCommand command)
        {
            var win32Process = this.win32ProcessRepository.GetProcessById(command.Win32ProcessId);
            if (win32Process == null)
            {
                return;
            }

            var remoteProcess = this.remoteProcessFactory.Create(win32Process);
            if (remoteProcess == null)
            {
                return;
            }

            this.remoteProcessRepository.Add(remoteProcess);
            this.events.Publish(new RemoteProcessCreatedEvent(remoteProcess.Id));
        }

        public void Handle(ICommand command)
        {
            this.Handle((CreateRemoteProcessCommand)command);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
            Contract.Invariant(this.win32ProcessRepository != null);
            Contract.Invariant(this.remoteProcessFactory != null);
            Contract.Invariant(this.remoteProcessRepository != null);
        }

        #endregion
    }
}