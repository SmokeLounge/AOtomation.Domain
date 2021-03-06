﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendMessageActionFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SendMessageActionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using SmokeLounge.AOtomation.Domain.Entities.Actions;

    [Export(typeof(ISendMessageActionFactory))]
    public class SendMessageActionFactory : ISendMessageActionFactory
    {
        #region Public Methods and Operators

        public ISendMessageAction Create(Guid actionId, Type messageType, IEnumerable<object> parameters)
        {
            return new SendMessageAction(actionId, messageType, parameters);
        }

        #endregion
    }
}