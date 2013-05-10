// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTriggerAddedToRemoteProcessEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageTriggerAddedToRemoteProcessEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Events
{
    using System;

    public class MessageTriggerAddedToRemoteProcessEvent
    {
        #region Fields

        private readonly Guid remoteProcessId;

        private readonly Guid triggerId;

        #endregion

        #region Constructors and Destructors

        public MessageTriggerAddedToRemoteProcessEvent(Guid remoteProcessId, Guid triggerId)
        {
            this.remoteProcessId = remoteProcessId;
            this.triggerId = triggerId;
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

        public Guid TriggerId
        {
            get
            {
                return this.triggerId;
            }
        }

        #endregion
    }
}