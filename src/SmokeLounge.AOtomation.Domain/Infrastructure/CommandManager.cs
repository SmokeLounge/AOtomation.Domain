// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandManager.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CommandManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    using SmokeLounge.AOtomation.Domain.Interfaces;

    [Export(typeof(ICommandManager))]
    public class CommandManager : ICommandManager
    {
        #region Fields

        private readonly IDictionary<Type, ICommandHandler> commandHandlers;

        #endregion

        #region Constructors and Destructors

        [ImportingConstructor]
        public CommandManager([ImportMany] IEnumerable<Lazy<ICommandHandler, ICommandHandlerMetadata>> commandHandlers)
        {
            Contract.Requires<ArgumentNullException>(commandHandlers != null);
            this.commandHandlers = new Dictionary<Type, ICommandHandler>();
            foreach (var commandHandler in commandHandlers)
            {
                Contract.Assume(commandHandler != null);
                Contract.Assume(commandHandler.Metadata != null);
                this.commandHandlers.Add(commandHandler.Metadata.HandlesCommand, commandHandler.Value);
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Enqueue(ICommand command)
        {
            ICommandHandler commandHandler;
            if (this.commandHandlers.TryGetValue(command.GetType(), out commandHandler) == false)
            {
                return;
            }

            Task.Run(() => commandHandler.Handle(command));
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.commandHandlers != null);
        }

        #endregion
    }
}