// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryManager.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MemoryManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interoperability
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using SmokeLounge.AOtomation.Domain.Entities;
    using SmokeLounge.AOtomation.Hook;

    [Export(typeof(IMemoryManager))]
    public class MemoryManager : IMemoryManager
    {
        #region Fields

        private readonly IReadProcessMemory readProcessMemory;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public MemoryManager(IReadProcessMemory readProcessMemory)
        {
            Contract.Requires<ArgumentNullException>(readProcessMemory != null);
            this.readProcessMemory = readProcessMemory;
        }

        #endregion

        #region Public Methods and Operators

        public byte[] Read(IRemoteProcess remoteProcess, MemoryMap memoryMap, int size)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.Read(remoteProcess.Handle, address, size);
        }

        public byte ReadByte(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadByte(remoteProcess.Handle, address);
        }

        public double ReadDouble(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadDouble(remoteProcess.Handle, address);
        }

        public short ReadInt16(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadInt16(remoteProcess.Handle, address);
        }

        public int ReadInt32(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadInt32(remoteProcess.Handle, address);
        }

        public long ReadInt64(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadInt64(remoteProcess.Handle, address);
        }

        public float ReadSingle(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadSingle(remoteProcess.Handle, address);
        }

        public string ReadString(IRemoteProcess remoteProcess, MemoryMap memoryMap, int? length = null)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadString(remoteProcess.Handle, address, length);
        }

        public ushort ReadUInt16(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadUInt16(remoteProcess.Handle, address);
        }

        public uint ReadUInt32(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadUInt32(remoteProcess.Handle, address);
        }

        public ulong ReadUInt64(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            var address = this.GetAddress(remoteProcess, memoryMap);
            return this.readProcessMemory.ReadUInt64(remoteProcess.Handle, address);
        }

        #endregion

        #region Methods

        private IntPtr GetAddress(IRemoteProcess remoteProcess, MemoryMap memoryMap)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(memoryMap != null);
            var module =
                remoteProcess.Modules.FirstOrDefault(
                    m => string.Equals(m.Name, memoryMap.DllName, StringComparison.OrdinalIgnoreCase));
            if (module == null)
            {
                return IntPtr.Zero;
            }

            return memoryMap.Offsets.Skip(1)
                            .Aggregate(
                                module.BaseAddress + memoryMap.Offsets.First(), 
                                (current, offset) =>
                                (IntPtr)(this.readProcessMemory.ReadInt32(remoteProcess.Handle, current) + offset));
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.readProcessMemory != null);
        }

        #endregion
    }
}