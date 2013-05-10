// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryMap.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MemoryMap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interoperability
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    public class MemoryMap
    {
        #region Fields

        private readonly string dllName;

        private readonly int[] offsets;

        #endregion

        #region Constructors and Destructors

        public MemoryMap(MemoryMap baseMap, params int[] offsets)
        {
            Contract.Requires<ArgumentNullException>(baseMap != null);
            Contract.Requires<ArgumentNullException>(offsets != null);
            this.dllName = baseMap.DllName;
            this.offsets = baseMap.Offsets.Concat(offsets).ToArray();
        }

        public MemoryMap(string dllName, params int[] offsets)
        {
            Contract.Requires<ArgumentNullException>(offsets != null);
            this.dllName = dllName;
            this.offsets = offsets;
        }

        #endregion

        #region Public Properties

        public string DllName
        {
            get
            {
                return this.dllName;
            }
        }

        public IReadOnlyCollection<int> Offsets
        {
            get
            {
                Contract.Ensures(Contract.Result<IReadOnlyCollection<int>>() != null);
                return this.offsets;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.offsets != null);
        }

        #endregion
    }
}