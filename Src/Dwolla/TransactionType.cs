//-----------------------------------------------------------------------
// <copyright file="TransactionType.cs">
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

namespace DwollaApi.Dwolla
{
    /// <summary>
    /// Dwolla TransactionsResult types.
    /// </summary>
    public sealed class TransactionType : Enumeration<TransactionType>
    {
        /// <summary>
        /// Money sent transaction type.
        /// </summary>
        public static readonly TransactionType Moneysent = new TransactionType("money_sent");

        /// <summary>
        /// Money recieved transaction type.
        /// </summary>
        public static readonly TransactionType Moneyrecieved = new TransactionType("money_recieved");

        /// <summary>
        /// Deposit transaction type.
        /// </summary>
        public static readonly TransactionType Deposit = new TransactionType("deposit");

        /// <summary>
        /// Withdrawal transaction type.
        /// </summary>
        public static readonly TransactionType Withdrawal = new TransactionType("withdrawal");

        /// <summary>
        /// Fee transaction type.
        /// </summary>
        public static readonly TransactionType Fee = new TransactionType("fee");

        private TransactionType(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TransactionType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TransactionType(string value)
        {
            return Convert(value, s => new TransactionType(s));
        }
    }
}