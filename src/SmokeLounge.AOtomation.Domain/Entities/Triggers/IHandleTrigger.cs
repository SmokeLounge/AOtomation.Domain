// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandleTrigger.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IHandleTrigger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities.Triggers
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IHandleTriggerContract))]
    public interface IHandleTrigger
    {
        #region Public Methods and Operators

        bool MeetsCriteria(ITrigger trigger, object criteria);

        #endregion
    }

    [ContractClass(typeof(IHandleTriggerContract<,>))]
    public interface IHandleTrigger<in TTrigger, in TCriteria> : IHandleTrigger
        where TTrigger : class, ITrigger where TCriteria : class
    {
        #region Public Methods and Operators

        bool MeetsCriteria(TTrigger trigger, TCriteria criteria);

        #endregion
    }

    [ContractClassFor(typeof(IHandleTrigger))]
    internal abstract class IHandleTriggerContract : IHandleTrigger
    {
        #region Public Methods and Operators

        public bool MeetsCriteria(ITrigger trigger, object criteria)
        {
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(criteria != null);

            throw new NotImplementedException();
        }

        #endregion
    }

    [ContractClassFor(typeof(IHandleTrigger<,>))]
    internal abstract class IHandleTriggerContract<TTrigger, TCriteria> : IHandleTrigger<TTrigger, TCriteria>
        where TTrigger : class, ITrigger where TCriteria : class
    {
        #region Public Methods and Operators

        public bool MeetsCriteria(TTrigger trigger, TCriteria criteria)
        {
            Contract.Requires<ArgumentNullException>(trigger != null);
            Contract.Requires<ArgumentNullException>(criteria != null);

            throw new NotImplementedException();
        }

        public bool MeetsCriteria(ITrigger trigger, object criteria)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}