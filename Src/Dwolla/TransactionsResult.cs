//-----------------------------------------------------------------------
// <copyright file="TransactionsResult.cs">
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

using System;
using DwollaApi.Converters;
using Newtonsoft.Json;

namespace DwollaApi.Dwolla
{
    [JsonObject]
    public class TransactionsResult
    {
        /// <summary>
        /// Supplies the transaction identifier.
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        /// <summary>
        /// Supplies the date of the transaction processed.
        /// </summary>
        [JsonProperty("Date")]
        [JsonConverter(typeof (EnUsDateTimeConverter))]
        public DateTime Date { get; internal set; }

        /// <summary>
        /// Supplies the amount of the transaction.
        /// </summary>
        [JsonProperty("Amount")]
        public decimal Amount { get; internal set; }

        /// <summary>
        /// Supplies the destination identifier of the user when type is money sent or withdrawal.
        /// </summary>
        [JsonProperty("DestinationId")]
        public string DestinationId { get; internal set; }

        /// <summary>
        /// Supplies the name of user when type is money sent or withdrawal.
        /// </summary>
        [JsonProperty("DestinationName")]
        public string DestinationName { get; internal set; }

        /// <summary>
        /// Supplies the name of the user when type is money recieved, deposit, or fee.
        /// </summary>
        [JsonProperty("SourceId")]
        public string SourceId { get; internal set; }

        /// <summary>
        /// Supplies the transaction type.
        /// </summary>
        [JsonProperty("SourceName")]
        public string SourceName { get; internal set; }

        /// <summary>
        /// Supplies the user type of the recieving account.
        /// </summary>
        [JsonProperty("Type")]
        [JsonConverter(typeof (TransactionTypeConverter))]
        public TransactionType Type { get; internal set; }

        /// <summary>
        /// Supplies the user type of the recieving account.
        /// </summary>
        [JsonConverter(typeof (UserTypeConverter))]
        [JsonProperty("UserType")]
        public UserType UserType { get; internal set; }

        /// <summary>
        /// Supplies the transaction status.
        /// </summary>
        [JsonProperty("Status")]
        [JsonConverter(typeof (TransactionStatusConverter))]
        public TransactionStatusType Status { get; internal set; }

        /// <summary>
        ///  Supplies the expected clearing date of the transaction.
        /// </summary>
        [JsonProperty("ClearingDate")]
        [JsonConverter(typeof (EnUsDateTimeConverter))]
        public DateTime ClearingDate { get; internal set; }
    }
}