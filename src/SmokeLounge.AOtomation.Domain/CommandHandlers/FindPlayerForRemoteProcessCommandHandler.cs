// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindPlayerForRemoteProcessCommandHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the FindPlayerForRemoteProcessCommandHandler type.
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
    using SmokeLounge.AOtomation.Domain.Interoperability;
    using SmokeLounge.AOtomation.Domain.Repositories;
    using SmokeLounge.AOtomation.Messaging.GameData;

    [ExportCommandHandler(typeof(FindPlayerForRemoteProcessCommand))]
    public class FindPlayerForRemoteProcessCommandHandler : ICommandHandler<FindPlayerForRemoteProcessCommand>
    {
        #region Fields

        private readonly IMemoryManager memoryManager;

        private readonly IPlayerFactory playerFactory;

        private readonly IPlayerRepository playerRepository;

        private readonly IRemoteProcessRepository remoteProcessRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public FindPlayerForRemoteProcessCommandHandler(
            IPlayerRepository playerRepository, 
            IRemoteProcessRepository remoteProcessRepository, 
            IMemoryManager memoryManager, 
            IPlayerFactory playerFactory)
        {
            Contract.Requires<ArgumentNullException>(playerRepository != null);
            Contract.Requires<ArgumentNullException>(remoteProcessRepository != null);
            Contract.Requires<ArgumentNullException>(memoryManager != null);
            Contract.Requires<ArgumentNullException>(playerFactory != null);

            this.playerRepository = playerRepository;
            this.remoteProcessRepository = remoteProcessRepository;
            this.memoryManager = memoryManager;
            this.playerFactory = playerFactory;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(FindPlayerForRemoteProcessCommand command)
        {
            var remoteProcess = this.remoteProcessRepository.Get(command.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }

            var name = this.memoryManager.ReadString(remoteProcess, MemoryMaps.Name);
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            var identityType = this.memoryManager.ReadInt32(remoteProcess, MemoryMaps.IdentityTypeInt);
            var identityValue = this.memoryManager.ReadInt32(remoteProcess, MemoryMaps.IdentityValueInt);

            var player =
                this.playerFactory.Create(
                    new Identity { Type = (IdentityType)identityType, Instance = identityValue }, name);
            if (player == null)
            {
                return;
            }

            remoteProcess.SetPlayer(player);
        }

        public void Handle(ICommand command)
        {
            this.Handle((FindPlayerForRemoteProcessCommand)command);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.playerRepository != null);
            Contract.Invariant(this.remoteProcessRepository != null);
            Contract.Invariant(this.memoryManager != null);
            Contract.Invariant(this.playerFactory != null);
        }

        #endregion
    }
}