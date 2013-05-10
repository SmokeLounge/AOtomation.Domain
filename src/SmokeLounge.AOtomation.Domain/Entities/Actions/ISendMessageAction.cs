// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISendMessageAction.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ISendMessageAction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Actions
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    [ContractClass(typeof(ISendMessageActionContract))]
    public interface ISendMessageAction : IGameAction
    {
    }

    [ContractClassFor(typeof(ISendMessageAction))]
    internal abstract class ISendMessageActionContract : ISendMessageAction
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
            throw new NotImplementedException();
        }

        #endregion
    }
}