// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessCreatedEventHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessCreatedEventHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.EventHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Infrastructure;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;
    using SmokeLounge.AOtomation.Domain.Interfaces.Events;

    [ExportEventHandler(typeof(RemoteProcessCreatedEvent))]
    public class RemoteProcessCreatedEventHandler : IHandleDomainEvent<RemoteProcessCreatedEvent>
    {
        #region Fields

        private readonly ICommandManager commandManager;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessCreatedEventHandler(ICommandManager commandManager)
        {
            Contract.Requires<ArgumentNullException>(commandManager != null);
            this.commandManager = commandManager;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(RemoteProcessCreatedEvent message)
        {
            this.commandManager.Enqueue(new AttachClientToRemoteProcessCommand(message.RemoteProcessId));
            this.commandManager.Enqueue(new FindPlayerForRemoteProcessCommand(message.RemoteProcessId));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.commandManager != null);
        }

        #endregion
    }
}