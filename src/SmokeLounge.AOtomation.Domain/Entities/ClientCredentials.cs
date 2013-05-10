// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientCredentials.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ClientCredentials type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Domain.Entities
{
    public class ClientCredentials
    {
        #region Fields

        private readonly string password;

        private readonly string username;

        #endregion

        #region Constructors and Destructors

        public ClientCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        #endregion

        #region Public Properties

        public string Password
        {
            get
            {
                return this.password;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
        }

        #endregion
    }
}