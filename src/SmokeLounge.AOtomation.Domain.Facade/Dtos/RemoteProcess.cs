// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoteProcess.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RemoteProcess type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade.Dtos
{
    using System;

    public class RemoteProcess
    {
        #region Constructors and Destructors

        protected RemoteProcess()
        {
        }

        #endregion

        #region Public Properties

        public Guid Id { get; private set; }

        public Player Player { get; private set; }

        public int RemoteId { get; private set; }

        #endregion
    }
}