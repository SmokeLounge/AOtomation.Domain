// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcessFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IProcessFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;

    [ContractClass(typeof(IProcessFactoryContract))]
    public interface IProcessFactory
    {
        #region Public Methods and Operators

        IProcess Create(ClientCredentials credentials);

        #endregion
    }

    [ContractClassFor(typeof(IProcessFactory))]
    internal abstract class IProcessFactoryContract : IProcessFactory
    {
        #region Public Methods and Operators

        public IProcess Create(ClientCredentials credentials)
        {
            Contract.Requires<ArgumentNullException>(credentials != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}