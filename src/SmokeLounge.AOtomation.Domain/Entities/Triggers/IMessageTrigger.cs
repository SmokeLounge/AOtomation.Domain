// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageTrigger.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IMessageTrigger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Actions;

    [ContractClass(typeof(IMessageTriggerContract))]
    public interface IMessageTrigger : ITrigger
    {
        #region Public Properties

        Type Handles { get; }

        #endregion
    }

    [ContractClassFor(typeof(IMessageTrigger))]
    internal abstract class IMessageTriggerContract : IMessageTrigger
    {
        #region Public Properties

        public IReadOnlyCollection<IGameAction> ActionsAfter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IGameAction> ActionsBefore
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Type Handles
        {
            get
            {
                Contract.Ensures(Contract.Result<Type>() != null);

                throw new NotImplementedException();
            }
        }

        public Guid Id { get; private set; }

        #endregion

        #region Public Methods and Operators

        public void AddActionAfter(IGameAction action)
        {
            throw new NotImplementedException();
        }

        public void AddActionBefore(IGameAction action)
        {
            throw new NotImplementedException();
        }

        public void ExecuteAfter(IActionExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public void ExecuteBefore(IActionExecutionContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}