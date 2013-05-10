// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionExecutionContext.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ActionExecutionContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Messaging.GameData;
    using SmokeLounge.AOtomation.Messaging.Messages;

    public class ActionExecutionContext : IActionExecutionContext
    {
        #region Fields

        private readonly IProcess remoteProcess;

        #endregion

        #region Constructors and Destructors

        public ActionExecutionContext(IProcess remoteProcess)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            this.remoteProcess = remoteProcess;
        }

        #endregion

        #region Public Properties

        public Identity PlayerId
        {
            get
            {
                return this.remoteProcess.Player == null ? Identity.None : this.remoteProcess.Player.RemoteId;
            }
        }

        public IEnumerable<ITrigger> Triggers
        {
            get
            {
                return this.remoteProcess.Triggers.Concat(this.remoteProcess.Triggers);
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Send(MessageBody message)
        {
            this.remoteProcess.Send(message);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteProcess != null);
        }

        #endregion
    }
}