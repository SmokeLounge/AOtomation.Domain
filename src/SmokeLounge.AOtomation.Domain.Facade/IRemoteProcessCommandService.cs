// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRemoteProcessCommandService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRemoteProcessCommandService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;

    [ContractClass(typeof(IRemoteProcessCommandServiceContract))]
    public interface IRemoteProcessCommandService
    {
        #region Public Methods and Operators

        void AttachClientToRemoteProcess(AttachClientToRemoteProcessCommand command);

        #endregion
    }

    [ContractClassFor(typeof(IRemoteProcessCommandService))]
    internal abstract class IRemoteProcessCommandServiceContract : IRemoteProcessCommandService
    {
        #region Public Methods and Operators

        public void AttachClientToRemoteProcess(AttachClientToRemoteProcessCommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}