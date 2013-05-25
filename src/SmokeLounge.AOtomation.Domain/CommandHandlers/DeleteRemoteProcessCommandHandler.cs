// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteRemoteProcessCommandHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DeleteRemoteProcessCommandHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.CommandHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Infrastructure;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;
    using SmokeLounge.AOtomation.Domain.Repositories;

    [ExportCommandHandler(typeof(DeleteRemoteProcessCommand))]
    public class DeleteRemoteProcessCommandHandler : ICommandHandler<DeleteRemoteProcessCommand>
    {
        #region Fields

        private readonly IBus bus;

        private readonly IRemoteProcessRepository remoteProcessRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public DeleteRemoteProcessCommandHandler(IBus bus, IRemoteProcessRepository remoteProcessRepository)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(remoteProcessRepository != null);
            this.bus = bus;
            this.remoteProcessRepository = remoteProcessRepository;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(DeleteRemoteProcessCommand command)
        {
            var remoteProcess = this.remoteProcessRepository.Get(command.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }

            this.remoteProcessRepository.Delete(remoteProcess);
            this.bus.Publish(new RemoteProcessDeletedEvent(command.RemoteProcessId));
        }

        public void Handle(ICommand command)
        {
            this.Handle((DeleteRemoteProcessCommand)command);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.bus != null);
            Contract.Invariant(this.remoteProcessRepository != null);
        }

        #endregion
    }
}