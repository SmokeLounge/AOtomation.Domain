// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionExecutionContext.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IActionExecutionContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IActionExecutionContextContract))]
    public interface IActionExecutionContext
    {
        #region Public Properties

        Identity PlayerId { get; }

        IEnumerable<ITrigger> Triggers { get; }

        #endregion

        #region Public Methods and Operators

        void Send(MessageBody message);

        #endregion
    }

    [ContractClassFor(typeof(IActionExecutionContext))]
    internal abstract class IActionExecutionContextContract : IActionExecutionContext
    {
        #region Public Properties

        public Identity PlayerId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ITrigger> Triggers
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<ITrigger>>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Send(MessageBody message)
        {
            Contract.Requires<ArgumentNullException>(message != null);
            throw new NotImplementedException();
        }

        #endregion
    }
}