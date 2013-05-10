// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessQueryService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessQueryService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using AutoMapper;

    using SmokeLounge.AOtomation.Domain.Facade.Dtos;
    using SmokeLounge.AOtomation.Domain.Repositories;

    [Export(typeof(IRemoteProcessQueryService))]
    public class RemoteProcessQueryService : IRemoteProcessQueryService
    {
        #region Fields

        private readonly IRemoteProcessRepository remoteProcessRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessQueryService(IRemoteProcessRepository remoteProcessRepository)
        {
            Contract.Requires<ArgumentNullException>(remoteProcessRepository != null);
            this.remoteProcessRepository = remoteProcessRepository;
        }

        #endregion

        #region Public Methods and Operators

        public RemoteProcess Get(Guid id)
        {
            var remoteProcess = this.remoteProcessRepository.Get(id);
            if (remoteProcess == null)
            {
                return null;
            }

            return Mapper.Map<RemoteProcess>(remoteProcess);
        }

        public IReadOnlyCollection<RemoteProcess> GetAll()
        {
            return this.remoteProcessRepository.GetAll().Select(Mapper.Map<RemoteProcess>).ToArray();
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(this.remoteProcessRepository != null);
        }

        #endregion
    }
}