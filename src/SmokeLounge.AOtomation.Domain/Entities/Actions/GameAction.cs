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

namespace SmokeLounge.AOtomation.Domain.Entities.Actions
{
    using System;

    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    public abstract class GameAction : IGameAction
    {
        #region Fields

        private readonly Guid id;

        #endregion

        #region Constructors and Destructors

        protected GameAction(Guid id)
        {
            this.id = id;
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

        #endregion

        #region Public Methods and Operators

        public abstract void Execute(IActionExecutionContext context);

        #endregion
    }
}