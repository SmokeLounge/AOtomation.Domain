// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PacketReceivedEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PacketReceivedEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Events
{
    using System;
    using System.Diagnostics.Contracts;

    public class PacketReceivedEvent
    {
        #region Fields

        private readonly byte[] packet;

        private readonly Guid processId;

        #endregion

        #region Constructors and Destructors

        public PacketReceivedEvent(Guid processId, byte[] packet)
        {
            Contract.Requires<ArgumentNullException>(packet != null);

            this.processId = processId;
            this.packet = packet;
        }

        #endregion

        #region Public Properties

        public byte[] Packet
        {
            get
            {
                Contract.Ensures(Contract.Result<byte[]>() != null);

                return this.packet;
            }
        }

        public Guid ProcessId
        {
            get
            {
                return this.processId;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.packet != null);
        }

        #endregion
    }
}