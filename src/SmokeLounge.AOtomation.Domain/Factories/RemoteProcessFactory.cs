// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Hook;

    [Export(typeof(IRemoteProcessFactory))]
    public class RemoteProcessFactory : IRemoteProcessFactory
    {
        #region Fields

        private readonly IBus bus;

        private readonly IChainTriggerHandlers chainTriggerHandlers;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessFactory(IChainTriggerHandlers chainTriggerHandlers, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(chainTriggerHandlers != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            this.chainTriggerHandlers = chainTriggerHandlers;
            this.bus = bus;
        }

        #endregion

        #region Public Methods and Operators

        public IRemoteProcess Create(IWin32Process win32Process)
        {
            return new RemoteProcess(win32Process, this.chainTriggerHandlers, this.bus);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.chainTriggerHandlers != null);
            Contract.Invariant(this.bus != null);
        }

        #endregion
    }
}