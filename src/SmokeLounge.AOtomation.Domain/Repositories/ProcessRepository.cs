// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessRepository.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessRepository type.
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

    [Export(typeof(IProcessRepository))]
    public class ProcessRepository : IProcessRepository
    {
        #region Fields

        private readonly Dictionary<Guid, IProcess> processStore;

        #endregion

        #region Constructors and Destructors

        public ProcessRepository()
        {
            this.processStore = new Dictionary<Guid, IProcess>();
        }

        #endregion

        #region Public Methods and Operators

        public void Add(IProcess entity)
        {
            this.processStore.Add(entity.Id, entity);
        }

        public void Delete(IProcess entity)
        {
            this.processStore.Remove(entity.Id);
        }

        public IProcess Get(Guid id)
        {
            IProcess process;
            if (this.processStore.TryGetValue(id, out process))
            {
                return process;
            }

            return null;
        }

        public IReadOnlyCollection<IProcess> GetAll()
        {
            return this.processStore.Values.ToArray();
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.processStore != null);
        }

        #endregion
    }
}