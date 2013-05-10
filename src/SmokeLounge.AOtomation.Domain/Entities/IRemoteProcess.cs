// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRemoteProcess.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRemoteProcess type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Hook;
    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IRemoteProcessContract))]
    public interface IRemoteProcess : IProcess
    {
        #region Public Properties

        IntPtr Handle { get; }

        IReadOnlyCollection<IWin32Module> Modules { get; }

        int RemoteId { get; }

        #endregion
    }

    [ContractClassFor(typeof(IRemoteProcess))]
    internal abstract class IRemoteProcessContract : IRemoteProcess
    {
        #region Public Properties

        public bool Connected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<IWin32Module> Modules
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<IWin32Module>>() != null);

                throw new NotImplementedException();
            }
        }

        public IPlayer Player
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int RemoteId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyCollection<ITrigger> Triggers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddTrigger(ITrigger trigger)
        {
            throw new NotImplementedException();
        }

        public void AttachClient(IClient client)
        {
            throw new NotImplementedException();
        }

        public void NextState()
        {
            throw new NotImplementedException();
        }

        public void Send(MessageBody message)
        {
            throw new NotImplementedException();
        }

        public void SetPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}