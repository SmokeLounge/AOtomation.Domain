// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoMapperConfiguration.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the DtoMapperConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Facade
{
    using AutoMapper;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Domain.Entities.Triggers;

    public static class DtoMapperConfiguration
    {
        #region Public Methods and Operators

        public static void Initialize()
        {
            Mapper.CreateMap<MessageTrigger, Dtos.MessageTrigger>();
            Mapper.CreateMap<Player, Dtos.Player>();
            Mapper.CreateMap<RemoteProcess, Dtos.RemoteProcess>();
        }

        #endregion
    }
}