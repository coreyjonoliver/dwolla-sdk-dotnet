﻿//-----------------------------------------------------------------------
// <copyright file="AccountInformationResult.cs">
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
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class AccountInformationResult
    {
        /// <summary>
        /// Supplies the Dwolla account identifier.
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        /// <summary>
        /// Supplies the company name associated with the Dwolla account.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Supplies the latitude of the Dwolla account.
        /// </summary>
        [JsonProperty("Latitude")]
        public decimal Latitude { get; internal set; }

        /// <summary>
        /// Supplies the longitude of the Dwolla account.
        /// </summary>
        [JsonProperty("Longitude")]
        public decimal Longitude { get; internal set; }

        /// <summary>
        /// Supplies the Dwolla account type.
        /// </summary>
        [JsonProperty("Type")]
        [JsonConverter(typeof(AccountInformationTypeConverter))]
        public AccountInformationType Type { get; internal set; }

        /// <summary>
        /// Supplies the city name.
        /// </summary>
        [JsonProperty("City")]
        public string City { get; internal set; }

        /// <summary>
        /// Supplies the state code.
        /// </summary>
        [JsonProperty("State")]
        public string State { get; internal set; }  
    }
}
