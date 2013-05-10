// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendMessageAction.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SendMessageAction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Common;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Messaging.Messages;

    public class SendMessageAction : GameAction, ISendMessageAction
    {
        #region Fields

        private readonly Type messageType;

        private readonly object[] parameters;

        #endregion

        #region Constructors and Destructors

        public SendMessageAction(Type messageType, IEnumerable<object> parameters)
            : base(Guid.NewGuid())
        {
            Contract.Requires<ArgumentNullException>(messageType != null);
            Contract.Requires<ArgumentNullException>(parameters != null);
            this.messageType = messageType;
            this.parameters = parameters.ToArray();
        }

        public SendMessageAction(Guid id, Type messageType, IEnumerable<object> parameters)
            : base(id)
        {
            Contract.Requires<ArgumentNullException>(messageType != null);
            Contract.Requires<ArgumentNullException>(parameters != null);
            this.messageType = messageType;
            this.parameters = parameters.ToArray();
        }

        #endregion

        #region Public Methods and Operators

        public override void Execute(IActionExecutionContext context)
        {
            var message = (MessageBody)this.messageType.GetInstanceDynamic(this.parameters);
            if (message == null)
            {
                return;
            }

            context.Send(message);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.messageType != null);
            Contract.Invariant(this.parameters != null);
        }

        #endregion
    }
}