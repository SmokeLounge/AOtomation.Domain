// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGameAction.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IGameAction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Actions
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    [ContractClass(typeof(IGameActionContract))]
    public interface IGameAction
    {
        #region Public Properties

        Guid Id { get; }

        #endregion

        #region Public Methods and Operators

        void Execute(IActionExecutionContext context);

        #endregion
    }

    [ContractClassFor(typeof(IGameAction))]
    internal abstract class IGameActionContract : IGameAction
    {
        #region Public Properties

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Execute(IActionExecutionContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}