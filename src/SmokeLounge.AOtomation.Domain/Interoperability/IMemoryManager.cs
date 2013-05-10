// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMemoryManager.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IMemoryManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interoperability
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Entities;

    [ContractClass(typeof(IMemoryManagerContract))]
    public interface IMemoryManager
    {
        #region Public Methods and Operators

        byte[] Read(IRemoteProcess remoteProcess, MemoryMap memoryMap, int size);

        byte ReadByte(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        double ReadDouble(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        short ReadInt16(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        int ReadInt32(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        long ReadInt64(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        float ReadSingle(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        string ReadString(IRemoteProcess remoteProcess, MemoryMap memoryMap, int? length = null);

        ushort ReadUInt16(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        uint ReadUInt32(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        ulong ReadUInt64(IRemoteProcess remoteProcess, MemoryMap memoryMap);

        #endregion
    }

    [ContractClassFor(typeof(IMemoryManager))]
    internal abstract class IMemoryManagerContract : IMemoryManager
    {
        #region Public Methods and Operators

        public byte[] Read(IRemoteProcess remoteProcess, MemoryMap memoryMap, int size)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public byte ReadByte(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public double ReadDouble(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public short ReadInt16(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public int ReadInt32(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public long ReadInt64(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public float ReadSingle(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public string ReadString(IRemoteProcess remoteProcess, MemoryMap memoryMap, int? length = null)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);
            Contract.Requires<ArgumentOutOfRangeException>(length == null || length >= 0);

            throw new NotImplementedException();
        }

        public ushort ReadUInt16(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public uint ReadUInt32(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        public ulong ReadUInt64(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}