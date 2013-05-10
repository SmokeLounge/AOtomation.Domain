// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerQueryService.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the PlayerQueryService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using AutoMapper;

    using SmokeLounge.AOtomation.Domain.Facade.Dtos;
    using SmokeLounge.AOtomation.Domain.Repositories;

    [Export(typeof(IPlayerQueryService))]
    public class PlayerQueryService : IPlayerQueryService
    {
        #region Fields

        private readonly IPlayerRepository playerRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public PlayerQueryService(IPlayerRepository playerRepository)
        {
            Contract.Requires<ArgumentNullException>(playerRepository != null);
            this.playerRepository = playerRepository;
        }

        #endregion

        #region Public Methods and Operators

        public Player Get(Guid id)
        {
            var player = this.playerRepository.Get(id);
            if (player == null)
            {
                return null;
            }

            return Mapper.Map<Player>(player);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.playerRepository != null);
        }

        #endregion
    }
}