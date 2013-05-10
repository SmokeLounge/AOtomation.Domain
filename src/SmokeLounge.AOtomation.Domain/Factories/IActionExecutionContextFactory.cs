// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionExecutionContextFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IActionExecutionContextFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    [ContractClass(typeof(IActionExecutionContextFactoryContract))]
    public interface IActionExecutionContextFactory
    {
        #region Public Methods and Operators

        IActionExecutionContext Create(IProcess remoteProcess);

        #endregion
    }

    [ContractClassFor(typeof(IActionExecutionContextFactory))]
    internal abstract class IActionExecutionContextFactoryContract : IActionExecutionContextFactory
    {
        #region Public Methods and Operators

        public IActionExecutionContext Create(IProcess remoteProcess)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Ensures(Contract.Result<IActionExecutionContext>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}