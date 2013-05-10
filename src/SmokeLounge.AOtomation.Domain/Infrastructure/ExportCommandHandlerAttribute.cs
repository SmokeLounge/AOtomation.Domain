// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportCommandHandlerAttribute.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ExportCommandHandlerAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.ComponentModel.Composition;

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCommandHandlerAttribute : ExportAttribute
    {
        #region Fields

        private readonly Type handlesCommand;

        #endregion

        #region Constructors and Destructors

        public ExportCommandHandlerAttribute(Type handlesCommand)
            : base(typeof(ICommandHandler))
        {
            this.handlesCommand = handlesCommand;
        }

        #endregion

        #region Public Properties

        public Type HandlesCommand
        {
            get
            {
                return this.handlesCommand;
            }
        }

        #endregion
    }
}