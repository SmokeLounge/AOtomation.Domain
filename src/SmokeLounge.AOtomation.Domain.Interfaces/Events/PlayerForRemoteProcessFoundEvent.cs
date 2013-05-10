// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerForRemoteProcessFoundEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayerForRemoteProcessFoundEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Events
{
    using System;

    public class PlayerForRemoteProcessFoundEvent
    {
        #region Fields

        private readonly Guid playerId;

        private readonly Guid remoteProcessId;

        #endregion

        #region Constructors and Destructors

        public PlayerForRemoteProcessFoundEvent(Guid remoteProcessId, Guid playerId)
        {
            this.remoteProcessId = remoteProcessId;
            this.playerId = playerId;
        }

        #endregion

        #region Public Properties

        public Guid PlayerId
        {
            get
            {
                return this.playerId;
            }
        }

        public Guid RemoteProcessId
        {
            get
            {
                return this.remoteProcessId;
            }
        }

        #endregion
    }
}