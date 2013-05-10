// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTrigger.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageTrigger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Diagnostics.Contracts;

    public class MessageTrigger : Trigger, IMessageTrigger
    {
        #region Fields

        private readonly Type handles;

        #endregion

        #region Constructors and Destructors

        public MessageTrigger(Type handles)
        {
            Contract.Requires<ArgumentNullException>(handles != null);
            this.handles = handles;
        }

        #endregion

        #region Public Properties

        public Type Handles
        {
            get
            {
                Contract.Ensures(Contract.Result<Type>() != null);
                return this.handles;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.handles != null);
        }

        #endregion
    }
}