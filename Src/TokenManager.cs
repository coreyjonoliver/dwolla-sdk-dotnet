//-----------------------------------------------------------------------
// <copyright file="TokenManager.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using DotNetOpenAuth.OAuth2;

namespace DwollaApi
{
    public class TokenManager : IClientAuthorizationTracker
    {
        #region IClientAuthorizationTracker Members

        public IAuthorizationState GetAuthorizationState(Uri callbackUrl, string clientState)
        {
            return new AuthorizationState
                       {
                           Callback = callbackUrl,
                       };
        }

        #endregion
    }
}