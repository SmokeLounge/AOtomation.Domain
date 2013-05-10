// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerRepository.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayerRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Entities;

    [Export(typeof(IPlayerRepository))]
    public class PlayerRepository : IPlayerRepository
    {
        #region Fields

        private readonly Dictionary<Guid, IPlayer> playerStore;

        #endregion

        #region Constructors and Destructors

        public PlayerRepository()
        {
            this.playerStore = new Dictionary<Guid, IPlayer>();
        }

        #endregion

        #region Public Methods and Operators

        public void Add(IPlayer entity)
        {
            this.playerStore.Add(entity.Id, entity);
        }

        public void Delete(IPlayer entity)
        {
            this.playerStore.Remove(entity.Id);
        }

        public IPlayer Get(Guid id)
        {
            IPlayer player;
            if (this.playerStore.TryGetValue(id, out player))
            {
                return player;
            }

            return null;
        }

        public IReadOnlyCollection<IPlayer> GetAll()
        {
            return this.playerStore.Select(r => r.Value).ToArray();
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.playerStore != null);
        }

        #endregion
    }
}