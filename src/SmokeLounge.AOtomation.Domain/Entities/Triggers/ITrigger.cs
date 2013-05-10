// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITrigger.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ITrigger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Actions;

    [ContractClass(typeof(ITriggerContract))]
    public interface ITrigger
    {
        #region Public Properties

        IReadOnlyCollection<IGameAction> ActionsAfter { get; }

        IReadOnlyCollection<IGameAction> ActionsBefore { get; }

        Guid Id { get; }

        #endregion

        #region Public Methods and Operators

        void AddActionAfter(IGameAction action);

        void AddActionBefore(IGameAction action);

        void ExecuteAfter(IActionExecutionContext context);

        void ExecuteBefore(IActionExecutionContext context);

        #endregion
    }

    [ContractClassFor(typeof(ITrigger))]
    internal abstract class ITriggerContract : ITrigger
    {
        #region Public Properties

        public IReadOnlyCollection<IGameAction> ActionsAfter
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<IGameAction>>() != null);

                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IGameAction> ActionsBefore
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<IGameAction>>() != null);

                throw new NotImplementedException();
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddActionAfter(IGameAction action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            throw new NotImplementedException();
        }

        public void AddActionBefore(IGameAction action)
        {
            Contract.Requires<ArgumentNullException>(action != null);

            throw new NotImplementedException();
        }

        public void ExecuteAfter(IActionExecutionContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null);

            throw new NotImplementedException();
        }

        public void ExecuteBefore(IActionExecutionContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}