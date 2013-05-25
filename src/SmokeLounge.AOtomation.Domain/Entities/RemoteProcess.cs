// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcess.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcess type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Hook;

    public class RemoteProcess : Process, IRemoteProcess
    {
        #region Fields

        private readonly IWin32Process win32Process;

        #endregion

        #region Constructors and Destructors

        public RemoteProcess(IWin32Process win32Process, IChainTriggerHandlers triggerHandler, IBus bus)
            : base(triggerHandler, bus)
        {
            Contract.Requires<ArgumentNullException>(win32Process != null);
            Contract.Requires<ArgumentNullException>(triggerHandler != null);
            Contract.Requires<ArgumentNullException>(bus != null);
            this.win32Process = win32Process;
        }

        #endregion

        #region Public Properties

        public IntPtr Handle
        {
            get
            {
                return this.win32Process.Handle;
            }
        }

        public IReadOnlyCollection<IWin32Module> Modules
        {
            get
            {
                return this.win32Process.Modules;
            }
        }

        public int RemoteId
        {
            get
            {
                return this.win32Process.Id;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.win32Process != null);
        }

        #endregion
    }
}