// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionExecutionContextFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ActionExecutionContextFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Factories
{
    using System.ComponentModel.Composition;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    [Export(typeof(IActionExecutionContextFactory))]
    public class ActionExecutionContextFactory : IActionExecutionContextFactory
    {
        #region Public Methods and Operators

        public IActionExecutionContext Create(IProcess remoteProcess)
        {
            return new ActionExecutionContext(remoteProcess);
        }

        #endregion
    }
}