// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportStartupTaskAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ExportStartupTaskAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.ComponentModel.Composition;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportStartupTaskAttribute : ExportAttribute
    {
        #region Constructors and Destructors

        public ExportStartupTaskAttribute()
            : base(typeof(ITask))
        {
        }

        #endregion

        #region Public Properties

        public int Priority { get; set; }

        #endregion
    }
}