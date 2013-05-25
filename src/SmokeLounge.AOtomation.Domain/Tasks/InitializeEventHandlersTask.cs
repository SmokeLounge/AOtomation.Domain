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

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Infrastructure;

    [ExportStartupTask(Priority = 10)]
    public class InitializeEventHandlersTask : IInitializeEventHandlersTask
    {
        #region Fields

        private readonly IBus bus;

        private readonly IEnumerable<Lazy<IHandleMessage, IMessageHandlerMetadata>> eventHandlers;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public InitializeEventHandlersTask(
            IBus bus, [ImportMany] IEnumerable<Lazy<IHandleMessage, IMessageHandlerMetadata>> eventHandlers)
        {
            Contract.Requires<ArgumentNullException>(bus != null);
            Contract.Requires<ArgumentNullException>(eventHandlers != null);

            this.bus = bus;
            this.eventHandlers = eventHandlers;
        }

        #endregion

        #region Public Methods and Operators

        public void Start()
        {
            foreach (var eventHandler in this.eventHandlers.Where(e => e.Value != null).Select(e => e.Value))
            {
                Contract.Assume(eventHandler != null);
                this.bus.Subscribe(eventHandler);
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.bus != null);
            Contract.Invariant(this.eventHandlers != null);
        }

        #endregion
    }
}