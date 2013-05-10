// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcess.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IProcess type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;
    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IProcessContract))]
    public interface IProcess
    {
        #region Public Properties

        Guid Id { get; }

        IPlayer Player { get; }

        IReadOnlyCollection<ITrigger> Triggers { get; }

        #endregion

        #region Public Methods and Operators

        void AddTrigger(ITrigger trigger);

        void AttachClient(IClient client);

        void Send(MessageBody message);

        void SetPlayer(IPlayer player);

        #endregion
    }

    [ContractClassFor(typeof(IProcess))]
    internal abstract class IProcessContract : IProcess
    {
        #region Public Properties

        public bool Connected
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

        public IPlayer Player
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
                Contract.Ensures(Contract.Result<IReadOnlyCollection<ITrigger>>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddTrigger(ITrigger trigger)
        {
            Contract.Requires<ArgumentNullException>(trigger != null);
        }

        public void AttachClient(IClient client)
        {
            Contract.Requires<ArgumentNullException>(client != null);

            throw new NotImplementedException();
        }

        public void Send(MessageBody message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        public void SetPlayer(IPlayer player)
        {
            Contract.Requires<ArgumentNullException>(player != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}