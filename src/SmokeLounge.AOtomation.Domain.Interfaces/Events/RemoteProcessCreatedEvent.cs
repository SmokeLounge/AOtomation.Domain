// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcessCreatedEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcessCreatedEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Events
{
    using System;

    public class RemoteProcessCreatedEvent
    {
        #region Fields

        private readonly Guid remoteProcessId;

        #endregion

        #region Constructors and Destructors

        public RemoteProcessCreatedEvent(Guid remoteProcessId)
        {
            this.remoteProcessId = remoteProcessId;
        }

        #endregion

        #region Public Properties

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