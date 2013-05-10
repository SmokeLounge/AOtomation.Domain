// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IMessageSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interoperability
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;

    using SmokeLounge.AOtomation.Messaging.Messages;

    [ContractClass(typeof(IMessageSerializerContract))]
    public interface IMessageSerializer
    {
        #region Public Methods and Operators

        Message Deserialize(Stream stream);

        void Serialize(Stream stream, Message message);

        #endregion
    }

    [ContractClassFor(typeof(IMessageSerializer))]
    internal abstract class IMessageSerializerContract : IMessageSerializer
    {
        #region Public Methods and Operators

        public Message Deserialize(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null);
            throw new NotImplementedException();
        }

        public void Serialize(Stream stream, Message message)
        {
            Contract.Requires<ArgumentNullException>(stream != null);
            Contract.Requires<ArgumentNullException>(message != null);
            throw new NotImplementedException();
        }

        #endregion
    }
}