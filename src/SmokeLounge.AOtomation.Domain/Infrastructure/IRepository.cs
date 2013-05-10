// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IRepositoryContract<>))]
    public interface IRepository<T>
        where T : class
    {
        #region Public Methods and Operators

        void Add(T entity);

        void Delete(T entity);

        T Get(Guid id);

        IReadOnlyCollection<T> GetAll();

        #endregion
    }

    [ContractClassFor(typeof(IRepository<>))]
    internal abstract class IRepositoryContract<T> : IRepository<T>
        where T : class
    {
        #region Public Methods and Operators

        public void Add(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null);

            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null);

            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<T> GetAll()
        {
            Contract.Ensures(Contract.Result<IReadOnlyCollection<T>>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}