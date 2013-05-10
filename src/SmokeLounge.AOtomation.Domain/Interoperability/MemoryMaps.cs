// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryMaps.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MemoryMaps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interoperability
{
    using System.Diagnostics.Contracts;

    public static class MemoryMaps
    {
        #region Constants

        private const string InterfacesDll = "Interfaces.dll";

        private const string N3Dll = "N3.dll";

        #endregion

        #region Static Fields

        private static readonly MemoryMap DynelInt;

        private static readonly MemoryMap NameInt;

        private static readonly MemoryMap identityTypeInt;

        private static readonly MemoryMap identityValueInt;

        #endregion

        #region Constructors and Destructors

        static MemoryMaps()
        {
            DynelInt = new MemoryMap(N3Dll, 0x5C4C0, 0x84);
            identityTypeInt = new MemoryMap(DynelInt, 0x14);
            identityValueInt = new MemoryMap(DynelInt, 0x18);
            NameInt = new MemoryMap(InterfacesDll, 0x31AE0);
        }

        #endregion

        #region Public Properties

        public static MemoryMap Dynel
        {
            get
            {
                Contract.Ensures(Contract.Result<MemoryMap>() != null);
                return DynelInt;
            }
        }

        public static MemoryMap IdentityTypeInt
        {
            get
            {
                Contract.Ensures(Contract.Result<MemoryMap>() != null);
                return identityTypeInt;
            }
        }

        public static MemoryMap IdentityValueInt
        {
            get
            {
                Contract.Ensures(Contract.Result<MemoryMap>() != null);
                return identityValueInt;
            }
        }

        public static MemoryMap Name
        {
            get
            {
                Contract.Ensures(Contract.Result<MemoryMap>() != null);
                return NameInt;
            }
        }

        #endregion
    }
}