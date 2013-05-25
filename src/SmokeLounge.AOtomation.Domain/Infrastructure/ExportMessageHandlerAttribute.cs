// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportMessageHandlerAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ExportMessageHandlerAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.ComponentModel.Composition;

    using SmokeLounge.AOtomation.Bus;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportMessageHandlerAttribute : ExportAttribute
    {
        #region Fields

        private readonly Type handlesEvent;

        #endregion

        #region Constructors and Destructors

        public ExportMessageHandlerAttribute(Type handlesEvent)
            : base(typeof(IHandleMessage))
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