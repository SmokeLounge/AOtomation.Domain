// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTriggerFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageTriggerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands.Parameters;

    [Export(typeof(IMessageTriggerFactory))]
    public class MessageTriggerFactory : IMessageTriggerFactory
    {
        #region Fields

        private readonly ISendMessageActionFactory sendMessageActionFactory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public MessageTriggerFactory(ISendMessageActionFactory sendMessageActionFactory)
        {
            Contract.Requires<ArgumentNullException>(sendMessageActionFactory != null);
            this.sendMessageActionFactory = sendMessageActionFactory;
        }

        #endregion

        #region Public Methods and Operators

        public IMessageTrigger Create(
            Type messageType, IEnumerable<GameAction> actionsBefore, IEnumerable<GameAction> actionsAfter)
        {
            var messageTrigger = new MessageTrigger(messageType);

            // TODO: Create action factory chain
            foreach (var gameAction in actionsBefore.OfType<SendMessageAction>())
            {
                Contract.Assume(gameAction != null);
                var action = this.sendMessageActionFactory.Create(gameAction.Id, gameAction.Type, gameAction.Parameters);
                messageTrigger.AddActionBefore(action);
            }

            foreach (var gameAction in actionsAfter.OfType<SendMessageAction>())
            {
                Contract.Assume(gameAction != null);
                var action = this.sendMessageActionFactory.Create(gameAction.Id, gameAction.Type, gameAction.Parameters);
                messageTrigger.AddActionAfter(action);
            }

            return messageTrigger;
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.sendMessageActionFactory != null);
        }

        #endregion
    }
}