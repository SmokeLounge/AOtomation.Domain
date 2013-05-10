// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessRepository.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessRepository type.
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

    [Export(typeof(IRemoteProcessRepository))]
    public class RemoteProcessRepository : IRemoteProcessRepository
    {
        #region Fields

        private readonly IProcessRepository processRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessRepository(IProcessRepository processRepository)
        {
            Contract.Requires<ArgumentNullException>(processRepository != null);
            this.processRepository = processRepository;
        }

        #endregion

        #region Public Methods and Operators

        public void Add(IRemoteProcess entity)
        {
            this.processRepository.Add(entity);
        }

        public void Delete(IRemoteProcess entity)
        {
            this.processRepository.Delete(entity);
        }

        public IRemoteProcess Get(Guid id)
        {
            return this.processRepository.Get(id) as IRemoteProcess;
        }

        public IReadOnlyCollection<IRemoteProcess> GetAll()
        {
            return this.processRepository.GetAll().OfType<IRemoteProcess>().ToArray();
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.processRepository != null);
        }

        #endregion
    }
}