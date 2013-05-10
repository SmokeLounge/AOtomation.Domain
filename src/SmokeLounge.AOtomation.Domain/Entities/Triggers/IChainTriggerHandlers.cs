// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChainTriggerHandlers.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IChainTriggerHandlers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IChainTriggerHandlersContract))]
    public interface IChainTriggerHandlers
    {
        #region Public Methods and Operators

        IActionExecutionContext CreateContext(IProcess remoteProcess);

        void ExecuteTriggerActions(MessageBody message, Action resumeHook, IActionExecutionContext context);

        #endregion
    }

    [ContractClassFor(typeof(IChainTriggerHandlers))]
    internal abstract class IChainTriggerHandlersContract : IChainTriggerHandlers
    {
        #region Public Methods and Operators

        public IActionExecutionContext CreateContext(IProcess remoteProcess)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Ensures(Contract.Result<IActionExecutionContext>() != null);

            throw new NotImplementedException();
        }

        public void ExecuteTriggerActions(MessageBody message, Action resumeHook, IActionExecutionContext context)
        {
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(resumeHook != null);
            Contract.Requires<ArgumentNullException>(context != null);
        }

        #endregion
    }
}