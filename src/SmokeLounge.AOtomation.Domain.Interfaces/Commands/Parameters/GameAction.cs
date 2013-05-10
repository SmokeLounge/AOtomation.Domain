// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameAction.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the GameAction type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Commands.Parameters
{
    using System;

    public abstract class GameAction
    {
        #region Fields

        private readonly Guid id = Guid.NewGuid();

        #endregion

        #region Public Properties

        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        #endregion
    }
}