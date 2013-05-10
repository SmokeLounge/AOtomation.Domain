// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddMessageTriggerToProcessCommand.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AddMessageTriggerToProcessCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces.Commands.Parameters;

    public class AddMessageTriggerToProcessCommand : ICommand
    {
        #region Fields

        private readonly List<GameAction> actionsAfter;

        private readonly List<GameAction> actionsBefore;

        private readonly Type messageType;

        private readonly Guid remoteProcessId;

        #endregion

        #region Constructors and Destructors

        public AddMessageTriggerToProcessCommand(
            Guid remoteProcessId, 
            Type messageType, 
            IEnumerable<GameAction> actionsBefore, 
            IEnumerable<GameAction> actionsAfter)
        {
            Contract.Requires<ArgumentNullException>(messageType != null);
            this.remoteProcessId = remoteProcessId;
            this.messageType = messageType;

            this.actionsAfter = new List<GameAction>();
            this.actionsBefore = new List<GameAction>();

            if (actionsAfter != null)
            {
                this.actionsAfter.AddRange(actionsAfter);
            }

            if (actionsBefore != null)
            {
                this.actionsBefore.AddRange(actionsBefore);
            }
        }

        #endregion

        #region Public Properties

        public IReadOnlyCollection<GameAction> ActionsAfter
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<GameAction>>() != null);
                return this.actionsAfter;
            }
        }

        public IReadOnlyCollection<GameAction> ActionsBefore
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<GameAction>>() != null);
                return this.actionsBefore;
            }
        }

        public Type MessageType
        {
            get
            {
                Contract.Ensures(Contract.Result<Type>() != null);
                return this.messageType;
            }
        }

        public Guid RemoteProcessId
        {
            get
            {
                return this.remoteProcessId;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.messageType != null);
            Contract.Invariant(this.actionsAfter != null);
            Contract.Invariant(this.actionsBefore != null);
        }

        #endregion
    }
}