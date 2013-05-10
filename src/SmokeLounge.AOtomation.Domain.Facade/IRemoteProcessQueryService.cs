// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRemoteProcessQueryService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRemoteProcessQueryService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Facade.Dtos;

    [ContractClass(typeof(IRemoteProcessQueryServiceContract))]
    public interface IRemoteProcessQueryService
    {
        #region Public Methods and Operators

        RemoteProcess Get(Guid id);

        IReadOnlyCollection<RemoteProcess> GetAll();

        #endregion
    }

    [ContractClassFor(typeof(IRemoteProcessQueryService))]
    internal abstract class IRemoteProcessQueryServiceContract : IRemoteProcessQueryService
    {
        #region Public Methods and Operators

        public RemoteProcess Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<RemoteProcess> GetAll()
        {
            Contract.Ensures(Contract.Result<IReadOnlyCollection<RemoteProcess>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}