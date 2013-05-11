// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainBootstrapper.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DomainBootstrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Infrastructure;

    [Export(typeof(IDomainBootstrapper))]
    public class DomainBootstrapper : IDomainBootstrapper
    {
        #region Fields

        private readonly IEnumerable<Lazy<ITask, IStartupTaskMetadata>> startupTasks;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public DomainBootstrapper([ImportMany] IEnumerable<Lazy<ITask, IStartupTaskMetadata>> startupTasks)
        {
            Contract.Requires<ArgumentNullException>(startupTasks != null);
            this.startupTasks = startupTasks;
        }

        #endregion

        #region Public Methods and Operators

        public void Shutdown()
        {
            // TODO: Implement start/stop events for the background tasks. 
            // Handle the events here so they can be terminated gracefully on exit.
        }

        public void Startup()
        {
            DtoMapperConfiguration.Initialize();
            var tasks =
                this.startupTasks.OrderByDescending(t => t.Metadata.Priority)
                    .Where(t => t.Value != null)
                    .Select(t => t.Value);
            foreach (var startupTask in tasks)
            {
                Contract.Assume(startupTask != null);
                startupTask.Start();
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.startupTasks != null);
        }

        #endregion
    }
}