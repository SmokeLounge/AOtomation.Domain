// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageTriggerFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IMessageTriggerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands.Parameters;

    [ContractClass(typeof(MessageTriggerFactoryContract))]
    public interface IMessageTriggerFactory
    {
        #region Public Methods and Operators

        IMessageTrigger Create(
            Type messageType, IEnumerable<GameAction> actionsBefore, IEnumerable<GameAction> actionsAfter);

        #endregion
    }

    [ContractClassFor(typeof(IMessageTriggerFactory))]
    internal abstract class MessageTriggerFactoryContract : IMessageTriggerFactory
    {
        #region Public Methods and Operators

        public IMessageTrigger Create(
            Type messageType, IEnumerable<GameAction> actionsBefore, IEnumerable<GameAction> actionsAfter)
        {
            Contract.Requires<ArgumentNullException>(messageType != null);
            Contract.Requires<ArgumentNullException>(actionsBefore != null);
            Contract.Requires<ArgumentNullException>(actionsAfter != null);
            Contract.Ensures(Contract.Result<IMessageTrigger>() != null);
            throw new NotImplementedException();
        }

        #endregion
    }
}