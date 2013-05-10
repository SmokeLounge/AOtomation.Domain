// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageSerializer.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the MessageSerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interoperability
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.IO;

    using SmokeLounge.AOtomation.Messaging.Messages;

    [Export(typeof(IMessageSerializer))]
    public class MessageSerializer : IMessageSerializer
    {
        #region Fields

        private readonly Messaging.Serialization.MessageSerializer messageSerializer;

        #endregion

        #region Constructors and Destructors

        public MessageSerializer()
        {
            this.messageSerializer = new Messaging.Serialization.MessageSerializer();
        }

        #endregion

        #region Public Methods and Operators

        public Message Deserialize(Stream stream)
        {
            return this.messageSerializer.Deserialize(stream);
        }

        public void Serialize(Stream stream, Message message)
        {
            this.messageSerializer.Serialize(stream, message);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.messageSerializer != null);
        }

        #endregion
    }
}