// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChainTriggerHandlers.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ChainTriggerHandlers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Factories;
    using SmokeLounge.AOtomation.Messaging.Messages;

    [Export(typeof(IChainTriggerHandlers))]
    public class ChainTriggerHandlers : IChainTriggerHandlers
    {
        #region Fields

        private readonly IActionExecutionContextFactory actionExecutionContextFactory;

        private readonly IHandleTrigger<IMessageTrigger, MessageBody> handleMessageTrigger;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public ChainTriggerHandlers(
            IHandleTrigger<IMessageTrigger, MessageBody> handleMessageTrigger, 
            IActionExecutionContextFactory actionExecutionContextFactory)
        {
            Contract.Requires<ArgumentNullException>(handleMessageTrigger != null);
            Contract.Requires<ArgumentNullException>(actionExecutionContextFactory != null);
            this.handleMessageTrigger = handleMessageTrigger;
            this.actionExecutionContextFactory = actionExecutionContextFactory;
        }

        #endregion

        #region Public Methods and Operators

        public IActionExecutionContext CreateContext(IProcess remoteProcess)
        {
            return this.actionExecutionContextFactory.Create(remoteProcess);
        }

        public void ExecuteTriggerActions(MessageBody message, Action resumeHook, IActionExecutionContext context)
        {
            var triggersToHandle = from trigger in context.Triggers.OfType<IMessageTrigger>()
                                   where this.handleMessageTrigger.MeetsCriteria(trigger, message)
                                   select trigger;
            var triggersToExecute = triggersToHandle.ToArray();

            foreach (var messageTrigger in triggersToExecute)
            {
                messageTrigger.ExecuteBefore(context);
            }

            resumeHook();

            foreach (var messageTrigger in triggersToExecute)
            {
                messageTrigger.ExecuteAfter(context);
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.handleMessageTrigger != null);
            Contract.Invariant(this.actionExecutionContextFactory != null);
        }

        #endregion
    }
}