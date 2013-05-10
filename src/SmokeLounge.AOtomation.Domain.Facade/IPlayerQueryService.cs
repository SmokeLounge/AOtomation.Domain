// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayerQueryService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IPlayerQueryService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Facade.Dtos;

    [ContractClass(typeof(IPlayerQueryServiceContract))]
    public interface IPlayerQueryService
    {
        #region Public Methods and Operators

        Player Get(Guid id);

        #endregion
    }

    [ContractClassFor(typeof(IPlayerQueryService))]
    internal abstract class IPlayerQueryServiceContract : IPlayerQueryService
    {
        #region Public Methods and Operators

        public Player Get(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}