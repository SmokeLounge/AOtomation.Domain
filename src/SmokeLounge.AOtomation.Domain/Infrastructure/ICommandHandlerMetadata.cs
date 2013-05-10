// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandHandlerMetadata.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ICommandHandlerMetadata type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(ICommandHandlerMetadataContract))]
    public interface ICommandHandlerMetadata
    {
        #region Public Properties

        Type HandlesCommand { get; }

        #endregion
    }

    [ContractClassFor(typeof(ICommandHandlerMetadata))]
    internal abstract class ICommandHandlerMetadataContract : ICommandHandlerMetadata
    {
        #region Public Properties

        public Type HandlesCommand
        {
            get
            {
                Contract.Ensures(Contract.Result<Type>() != null);

                throw new NotImplementedException();
            }
        }

        #endregion
    }
}