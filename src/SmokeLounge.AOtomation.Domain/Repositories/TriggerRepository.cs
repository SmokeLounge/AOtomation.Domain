// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TriggerRepository.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the TriggerRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    [Export(typeof(ITriggerRepository))]
    public class TriggerRepository : ITriggerRepository
    {
        #region Fields

        private readonly Dictionary<Guid, ITrigger> triggerStore;

        #endregion

        #region Constructors and Destructors

        public TriggerRepository()
        {
            this.triggerStore = new Dictionary<Guid, ITrigger>();
        }

        #endregion

        #region Public Methods and Operators

        public void Add(ITrigger entity)
        {
            this.triggerStore.Add(entity.Id, entity);
        }

        public void Delete(ITrigger entity)
        {
            this.triggerStore.Remove(entity.Id);
        }

        public ITrigger Get(Guid id)
        {
            ITrigger trigger;
            if (this.triggerStore.TryGetValue(id, out trigger))
            {
                return trigger;
            }

            return null;
        }

        public IReadOnlyCollection<ITrigger> GetAll()
        {
            return this.triggerStore.Select(r => r.Value).ToArray();
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.triggerStore != null);
        }

        #endregion
    }
}