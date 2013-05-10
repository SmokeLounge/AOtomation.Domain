// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientRepository.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ClientRepository type.
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

    [Export(typeof(IClientRepository))]
    public class ClientRepository : IClientRepository
    {
        #region Fields

        private readonly Dictionary<Guid, IClient> clientStore;

        #endregion

        #region Constructors and Destructors

        public ClientRepository()
        {
            this.clientStore = new Dictionary<Guid, IClient>();
        }

        #endregion

        #region Public Methods and Operators

        public void Add(IClient entity)
        {
            this.clientStore.Add(entity.Id, entity);
        }

        public void Delete(IClient entity)
        {
            this.clientStore.Remove(entity.Id);
        }

        public IClient Get(Guid id)
        {
            IClient client;
            if (this.clientStore.TryGetValue(id, out client))
            {
                return client;
            }

            return null;
        }

        public IReadOnlyCollection<IClient> GetAll()
        {
            return this.clientStore.Select(r => r.Value).ToArray();
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.clientStore != null);
        }

        #endregion
    }
}