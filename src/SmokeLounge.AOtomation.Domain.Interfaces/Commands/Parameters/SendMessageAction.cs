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

namespace SmokeLounge.AOtomation.Domain.Interfaces.Commands.Parameters
{
    using System;
    using System.Diagnostics.Contracts;

    public class SendMessageAction : GameAction
    {
        #region Fields

        private readonly object[] parameters;

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public SendMessageAction(Type type, object[] parameters)
        {
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(parameters != null);
            this.type = type;
            this.parameters = parameters;
        }

        #endregion

        #region Public Properties

        public object[] Parameters
        {
            get
            {
                Contract.Ensures(Contract.Result<object[]>() != null);
                return this.parameters;
            }
        }

        public Type Type
        {
            get
            {
                Contract.Ensures(Contract.Result<Type>() != null);
                return this.type;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.type != null);
            Contract.Invariant(this.parameters != null);
        }

        #endregion
    }
}