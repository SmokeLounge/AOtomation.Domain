// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Player type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Messaging.GameData;

    public class Player : IPlayer
    {
        #region Fields

        private readonly Guid id = Guid.NewGuid();

        private readonly string name;

        private readonly Identity remoteId;

        #endregion

        #region Constructors and Destructors

        public Player(Identity remoteId, string name)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            this.remoteId = remoteId;
            this.name = name;
        }

        #endregion

        #region Public Properties

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Identity RemoteId
        {
            get
            {
                return this.remoteId;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.remoteId != null);
            Contract.Invariant(this.name != null);
        }

        #endregion
    }
}