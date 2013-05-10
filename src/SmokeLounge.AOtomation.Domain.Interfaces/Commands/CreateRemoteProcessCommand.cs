// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateRemoteProcessCommand.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CreateRemoteProcessCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Interfaces.Commands
{
    public class CreateRemoteProcessCommand : ICommand
    {
        #region Fields

        private readonly int win32ProcessId;

        #endregion

        #region Constructors and Destructors

        public CreateRemoteProcessCommand(int win32ProcessId)
        {
            this.win32ProcessId = win32ProcessId;
        }

        #endregion

        #region Public Properties

        public int Win32ProcessId
        {
            get
            {
                return this.win32ProcessId;
            }
        }

        #endregion
    }
}