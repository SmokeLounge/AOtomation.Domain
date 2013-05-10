// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITriggerCommandService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ITriggerCommandService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;

    [ContractClass(typeof(ITriggerCommandServiceContract))]
    public interface ITriggerCommandService
    {
        #region Public Methods and Operators

        void CreateTrigger(AddMessageTriggerToProcessCommand command);

        #endregion
    }

    [ContractClassFor(typeof(ITriggerCommandService))]
    internal abstract class ITriggerCommandServiceContract : ITriggerCommandService
    {
        #region Public Methods and Operators

        public void CreateTrigger(AddMessageTriggerToProcessCommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}