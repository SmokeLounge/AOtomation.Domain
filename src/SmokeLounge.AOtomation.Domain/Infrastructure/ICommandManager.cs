// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandManager.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ICommandManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces;

    [ContractClass(typeof(ICommandManagerContract))]
    public interface ICommandManager
    {
        #region Public Methods and Operators

        void Enqueue(ICommand command);

        #endregion
    }

    [ContractClassFor(typeof(ICommandManager))]
    internal abstract class ICommandManagerContract : ICommandManager
    {
        #region Public Methods and Operators

        public void Enqueue(ICommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}