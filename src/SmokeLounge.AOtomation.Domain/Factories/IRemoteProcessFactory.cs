// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRemoteProcessFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRemoteProcessFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Hook;

    [ContractClass(typeof(IRemoteProcessFactoryContract))]
    public interface IRemoteProcessFactory
    {
        #region Public Methods and Operators

        IRemoteProcess Create(IWin32Process win32Process);

        #endregion
    }

    [ContractClassFor(typeof(IRemoteProcessFactory))]
    internal abstract class IRemoteProcessFactoryContract : IRemoteProcessFactory
    {
        #region Public Methods and Operators

        public IRemoteProcess Create(IWin32Process win32Process)
        {
            Contract.Requires<ArgumentNullException>(win32Process != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}