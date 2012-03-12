﻿//-----------------------------------------------------------------------
// <copyright file="Scope.cs">
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
    /// Dwolla scopes.
    /// </summary>
    public sealed class Scope : Enumeration<Scope>
    {
        /// <summary>
        /// Balance scope.
        /// </summary>
        public static readonly Scope BALANCE = new Scope("Balance");

        /// <summary>
        /// Contacts scope.
        /// </summary>
        public static readonly Scope CONTACTS = new Scope("Contacts");

        /// <summary>
        /// Transactions scope.
        /// </summary>
        public static readonly Scope TRANSACTIONS = new Scope("Transactions");

        /// <summary>
        /// Send scope.
        /// </summary>
        public static readonly Scope SEND = new Scope("Send");

        /// <summary>
        /// Request scope.
        /// </summary>
        public static readonly Scope REQUEST = new Scope("Request");

        /// <summary>
        /// AccountInfoFull scope.
        /// </summary>
        public static readonly Scope ACCOUNTINFOFULL = new Scope("AccountInfoFull");

        private Scope(string value)
            : base(value)
        {
        }

        private Scope(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Scope"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Scope(string value)
        {
            return Convert(value, s => new Scope(s));
        }
    }
}