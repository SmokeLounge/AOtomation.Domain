// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trigger.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Trigger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Actions;

    public abstract class Trigger : ITrigger
    {
        #region Fields

        private readonly List<IGameAction> actionsAfter;

        private readonly List<IGameAction> actionsBefore;

        private readonly Guid id = Guid.NewGuid();

        #endregion

        #region Constructors and Destructors

        protected Trigger()
        {
            this.actionsAfter = new List<IGameAction>();
            this.actionsBefore = new List<IGameAction>();
        }

        #endregion

        #region Public Properties

        public IReadOnlyCollection<IGameAction> ActionsAfter
        {
            get
            {
                return this.actionsAfter;
            }
        }

        public IReadOnlyCollection<IGameAction> ActionsBefore
        {
            get
            {
                return this.actionsBefore;
            }
        }

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddActionAfter(IGameAction action)
        {
            this.actionsAfter.Add(action);
        }

        public void AddActionBefore(IGameAction action)
        {
            this.actionsBefore.Add(action);
        }

        public void ExecuteAfter(IActionExecutionContext context)
        {
            this.actionsAfter.ForEach(a => a.Execute(context));
        }

        public void ExecuteBefore(IActionExecutionContext context)
        {
            this.actionsBefore.ForEach(a => a.Execute(context));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.actionsAfter != null);
            Contract.Invariant(this.actionsBefore != null);
        }

        #endregion
    }
}