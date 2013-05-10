// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessMonitorTask.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessMonitorTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Tasks
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Timers;

    using SmokeLounge.AOtomation.Domain.Infrastructure;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;
    using SmokeLounge.AOtomation.Domain.Repositories;
    using SmokeLounge.AOtomation.Hook;

    using Timer = System.Timers.Timer;

    [ExportStartupTask]
    [Export(typeof(IRemoteProcessMonitorTask))]
    public sealed class RemoteProcessMonitorTask : IRemoteProcessMonitorTask, IDisposable
    {
        #region Fields

        private readonly ICommandManager commandManager;

        private readonly IRemoteProcessRepository remoteProcessRepository;

        private readonly Timer timer;

        private readonly IWin32ProcessRepository win32ProcessRepository;

        private int findProcessesLock;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public RemoteProcessMonitorTask(
            ICommandManager commandManager, 
            IWin32ProcessRepository win32ProcessRepository, 
            IRemoteProcessRepository remoteProcessRepository)
        {
            Contract.Requires<ArgumentNullException>(commandManager != null);
            Contract.Requires<ArgumentNullException>(win32ProcessRepository != null);
            Contract.Requires<ArgumentNullException>(remoteProcessRepository != null);
            this.commandManager = commandManager;
            this.win32ProcessRepository = win32ProcessRepository;
            this.remoteProcessRepository = remoteProcessRepository;

            this.timer = new Timer(TimeSpan.FromMilliseconds(1000).TotalMilliseconds);
            this.timer.Elapsed += this.TimerElapsedEventHandler;
        }

        #endregion

        #region Public Methods and Operators

        public void Dispose()
        {
            this.Stop();
            this.timer.Dispose();
        }

        public void Start()
        {
            this.FindProcesses();
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        #endregion

        #region Methods

        private void FindProcesses()
        {
            if (Interlocked.CompareExchange(ref this.findProcessesLock, 1, 0) == 1)
            {
                return;
            }

            var win32Processes = this.win32ProcessRepository.GetProcessesByName("AnarchyOnline");

            var processes = this.remoteProcessRepository.GetAll();
            var deadProcesses = from remoteProcess in processes.Where(p => p != null)
                                join win32Process in win32Processes on remoteProcess.RemoteId equals win32Process.Id
                                    into aliveWin32Processes
                                from win32Process in aliveWin32Processes.DefaultIfEmpty()
                                where win32Process == null || win32Process.HasExited
                                select remoteProcess;
            foreach (var remoteProcess in deadProcesses.ToArray())
            {
                Contract.Assume(remoteProcess != null);
                this.commandManager.Enqueue(new DeleteRemoteProcessCommand(remoteProcess.Id));
            }

            var newProcesses = from win32Process in win32Processes
                               join remoteProcess in processes on win32Process.Id equals remoteProcess.RemoteId into
                                   aliveRemoteProcesses
                               from remoteProcess in aliveRemoteProcesses.DefaultIfEmpty()
                               where remoteProcess == null
                               select win32Process;
            foreach (var newProcess in newProcesses)
            {
                Contract.Assume(newProcess != null);
                this.commandManager.Enqueue(new CreateRemoteProcessCommand(newProcess.Id));
            }

            Interlocked.Decrement(ref this.findProcessesLock);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.commandManager != null);
            Contract.Invariant(this.remoteProcessRepository != null);
            Contract.Invariant(this.win32ProcessRepository != null);
            Contract.Invariant(this.timer != null);
        }

        private void TimerElapsedEventHandler(object sender, ElapsedEventArgs e)
        {
            this.FindProcesses();
        }

        #endregion
    }
}