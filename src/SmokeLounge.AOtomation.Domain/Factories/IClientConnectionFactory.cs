// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientConnectionFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IClientConnectionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;

    [ContractClass(typeof(IClientConnectionFactoryContract))]
    public interface IClientConnectionFactory
    {
        #region Public Methods and Operators

        IClientConnection Create(int remoteProcessId, IntPtr remoteProcessHandle);

        #endregion
    }

    [ContractClassFor(typeof(IClientConnectionFactory))]
    internal abstract class IClientConnectionFactoryContract : IClientConnectionFactory
    {
        #region Public Methods and Operators

        public IClientConnection Create(int remoteProcessId, IntPtr remoteProcessHandle)
        {
            Contract.Ensures(Contract.Result<IClientConnection>() != null);
            throw new NotImplementedException();
        }

        #endregion
    }
}