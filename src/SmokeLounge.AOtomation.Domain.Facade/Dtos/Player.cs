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

namespace SmokeLounge.AOtomation.Domain.Facade.Dtos
{
    using System;

    using SmokeLounge.AOtomation.Messaging.GameData;

    public class Player
    {
        #region Constructors and Destructors

        protected Player()
        {
        }

        #endregion

        #region Public Properties

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Identity RemoteId { get; private set; }

        #endregion
    }
}