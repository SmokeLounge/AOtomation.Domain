// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportEventHandlerAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ExportEventHandlerAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.ComponentModel.Composition;

    using SmokeLounge.AOtomation.Domain.Interfaces;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportEventHandlerAttribute : ExportAttribute
    {
        #region Fields

        private readonly Type handlesEvent;

        #endregion

        #region Constructors and Destructors

        public ExportEventHandlerAttribute(Type handlesEvent)
            : base(typeof(IHandleDomainEvent))
        {
            this.handlesEvent = handlesEvent;
        }

        #endregion

        #region Public Properties

        public Type HandlesEvent
        {
            get
            {
                return this.handlesEvent;
            }
        }

        #endregion
    }
}