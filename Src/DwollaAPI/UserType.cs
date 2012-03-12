﻿//-----------------------------------------------------------------------
// <copyright file="UserType.cs">
// Copyright (c) 2012 Corey Oliver
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>
// <author>corey.jon.oliver@gmail.com</author>
//-----------------------------------------------------------------------

namespace Dwolla.API
{
    /// <summary>
    /// Dwolla User types.
    /// </summary>
    public sealed class UserType : Enumeration<UserType>
    {
        /// <summary>
        /// Dwolla user type.
        /// </summary>
        public static readonly UserType DWOLLA = new UserType("Dwolla"); 

        /// <summary>
        /// Facebook user type.
        /// </summary>
        public static readonly UserType FACEBOOK = new UserType("Facebook");

        /// <summary>
        /// Twitter user type.
        /// </summary>
        public static readonly UserType TWITTER = new UserType("Twitter");

        /// <summary>
        /// Email user type.
        /// </summary>
        public static readonly UserType EMAIL = new UserType("Email");

        /// <summary>
        /// Phone user type.
        /// </summary>
        public static readonly UserType PHONE = new UserType("Phone");

        private UserType(string value)
            : base(value)
        {
        }

        private UserType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="UserType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UserType(string value)
        {
            return Convert(value, s => new UserType(s));
        }
    }
}