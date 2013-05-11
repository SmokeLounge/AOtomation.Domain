// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IClientFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;

    [ContractClass(typeof(IClientFactoryContract))]
    public interface IClientFactory
    {
        #region Public Methods and Operators

        IClient Create(int remoteProcessId);

        #endregion
    }

    [ContractClassFor(typeof(IClientFactory))]
    internal abstract class IClientFactoryContract : IClientFactory
    {
        #region Public Methods and Operators

        public IClient Create(int remoteProcessId)
        {
            Contract.Ensures(Contract.Result<IClient>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}