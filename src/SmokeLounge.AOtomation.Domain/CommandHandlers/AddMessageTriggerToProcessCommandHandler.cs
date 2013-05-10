// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddMessageTriggerToProcessCommandHandler.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the AddMessageTriggerToProcessCommandHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.CommandHandlers
{
    using System;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Domain.Factories;
    using SmokeLounge.AOtomation.Domain.Infrastructure;
    using SmokeLounge.AOtomation.Domain.Interfaces;
    using SmokeLounge.AOtomation.Domain.Interfaces.Commands;
    using SmokeLounge.AOtomation.Domain.Repositories;

    [ExportCommandHandler(typeof(AddMessageTriggerToProcessCommand))]
    public class AddMessageTriggerToProcessCommandHandler : ICommandHandler<AddMessageTriggerToProcessCommand>
    {
        #region Fields

        private readonly IMessageTriggerFactory messageTriggerFactory;

        private readonly IProcessRepository processRepository;

        private readonly ITriggerRepository triggerRepository;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public AddMessageTriggerToProcessCommandHandler(
            IProcessRepository processRepository, 
            ITriggerRepository triggerRepository, 
            IMessageTriggerFactory messageTriggerFactory)
        {
            Contract.Requires<ArgumentNullException>(processRepository != null);
            Contract.Requires<ArgumentNullException>(triggerRepository != null);
            Contract.Requires<ArgumentNullException>(messageTriggerFactory != null);
            this.processRepository = processRepository;
            this.messageTriggerFactory = messageTriggerFactory;
            this.triggerRepository = triggerRepository;
        }

        #endregion

        #region Public Methods and Operators

        public void Handle(AddMessageTriggerToProcessCommand command)
        {
            var remoteProcess = this.processRepository.Get(command.RemoteProcessId);
            if (remoteProcess == null)
            {
                return;
            }

            var messageTrigger = this.messageTriggerFactory.Create(
                command.MessageType, command.ActionsBefore, command.ActionsAfter);
            this.triggerRepository.Add(messageTrigger);
            remoteProcess.AddTrigger(messageTrigger);
        }

        #endregion

        #region Explicit Interface Methods

        void ICommandHandler.Handle(ICommand command)
        {
            this.Handle((AddMessageTriggerToProcessCommand)command);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.processRepository != null);
            Contract.Invariant(this.triggerRepository != null);
            Contract.Invariant(this.messageTriggerFactory != null);
        }

        #endregion
    }
}