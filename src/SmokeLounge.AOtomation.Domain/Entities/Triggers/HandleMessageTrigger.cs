// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandleMessageTrigger.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the HandleMessageTrigger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System.ComponentModel.Composition;

    using SmokeLounge.AOtomation.Messaging.Messages;

    [Export(typeof(IHandleTrigger))]
    [Export(typeof(IHandleTrigger<IMessageTrigger, MessageBody>))]
    public class HandleMessageTrigger : IHandleTrigger<IMessageTrigger, MessageBody>
    {
        #region Public Methods and Operators

        public bool MeetsCriteria(IMessageTrigger trigger, MessageBody criteria)
        {
            return trigger.Handles == criteria.GetType();
        }

        public bool MeetsCriteria(ITrigger trigger, object criteria)
        {
            return this.MeetsCriteria((IMessageTrigger)trigger, (MessageBody)criteria);
        }

        #endregion
    }
}