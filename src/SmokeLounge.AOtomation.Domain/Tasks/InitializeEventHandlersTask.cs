// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitializeEventHandlersTask.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the InitializeEventHandlersTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Infrastructure;
    using SmokeLounge.AOtomation.Domain.Interfaces;

    [ExportStartupTask(Priority = 10)]
    public class InitializeEventHandlersTask : IInitializeEventHandlersTask
    {
        #region Fields

        private readonly IEnumerable<Lazy<IHandleDomainEvent, IEventHandlerMetadata>> eventHandlers;

        private readonly IDomainEventAggregator events;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public InitializeEventHandlersTask(
            IDomainEventAggregator events, 
            [ImportMany] IEnumerable<Lazy<IHandleDomainEvent, IEventHandlerMetadata>> eventHandlers)
        {
            Contract.Requires<ArgumentNullException>(events != null);
            Contract.Requires<ArgumentNullException>(eventHandlers != null);

            this.events = events;
            this.eventHandlers = eventHandlers;
        }

        #endregion

        #region Public Methods and Operators

        public void Start()
        {
            foreach (var eventHandler in this.eventHandlers.Where(e => e.Value != null).Select(e => e.Value))
            {
                Contract.Assume(eventHandler != null);
                this.events.Subscribe(eventHandler);
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.events != null);
            Contract.Invariant(this.eventHandlers != null);
        }

        #endregion
    }
}