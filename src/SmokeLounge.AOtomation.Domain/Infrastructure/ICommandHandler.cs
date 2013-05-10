// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ICommandHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Interfaces;

    [ContractClass(typeof(ICommandHandlerContract))]
    public interface ICommandHandler
    {
        #region Public Methods and Operators

        void Handle(ICommand command);

        #endregion
    }

    [ContractClass(typeof(ICommandHandlerContract<>))]
    public interface ICommandHandler<in T> : ICommandHandler
        where T : class, ICommand
    {
        #region Public Methods and Operators

        void Handle(T command);

        #endregion
    }

    [ContractClassFor(typeof(ICommandHandler))]
    internal abstract class ICommandHandlerContract : ICommandHandler
    {
        #region Public Methods and Operators

        public void Handle(ICommand command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            throw new NotImplementedException();
        }

        #endregion
    }

    [ContractClassFor(typeof(ICommandHandler<>))]
    internal abstract class ICommandHandlerContract<T> : ICommandHandler<T>
        where T : class, ICommand
    {
        #region Public Methods and Operators

        public void Handle(T command)
        {
            Contract.Requires<ArgumentNullException>(command != null);

            throw new NotImplementedException();
        }

        public void Handle(ICommand command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}