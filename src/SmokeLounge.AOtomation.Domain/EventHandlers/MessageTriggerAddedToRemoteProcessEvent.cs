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

namespace SmokeLounge.AOtomation.Domain.EventHandlers
{
    using SmokeLounge.AOtomation.Bus;
    using SmokeLounge.AOtomation.Domain.Infrastructure;

    [ExportMessageHandler(typeof(Interfaces.Events.MessageTriggerAddedToRemoteProcessEvent))]
    public class MessageTriggerAddedToRemoteProcessEvent :
        IHandleMessage<Interfaces.Events.MessageTriggerAddedToRemoteProcessEvent>
    {
        #region Public Methods and Operators

        public void Handle(Interfaces.Events.MessageTriggerAddedToRemoteProcessEvent message)
        {
        }

        #endregion
    }
}