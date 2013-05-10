// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISendMessageActionFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ISendMessageActionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Actions;

    [ContractClass(typeof(ISendMessageActionFactoryContract))]
    public interface ISendMessageActionFactory
    {
        #region Public Methods and Operators

        ISendMessageAction Create(Guid actionId, Type messageType, IEnumerable<object> parameters);

        #endregion
    }

    [ContractClassFor(typeof(ISendMessageActionFactory))]
    internal abstract class ISendMessageActionFactoryContract : ISendMessageActionFactory
    {
        #region Public Methods and Operators

        public ISendMessageAction Create(Guid actionId, Type messageType, IEnumerable<object> parameters)
        {
            Contract.Requires<ArgumentNullException>(messageType != null);
            Contract.Requires<ArgumentNullException>(parameters != null);
            Contract.Ensures(Contract.Result<ISendMessageAction>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}