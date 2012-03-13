//-----------------------------------------------------------------------
// <copyright file="DwollaClient.cs">
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

namespace Dwolla
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net;
    using System.Linq;
    using System.Text;
    using System.Web;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OAuth2;
    using Dwolla.API;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// An OAuth 2.0 consumer designed for utilizing the Dwolla REST API.
    /// </summary>
    public class DwollaClient : WebServerClient
    {
        private static readonly AuthorizationServerDescription DwollaDescription = new AuthorizationServerDescription
        {
            TokenEndpoint = new Uri("https://www.dwolla.com/oauth/v2/token"),
            AuthorizationEndpoint = new Uri("https://www.dwolla.com/oauth/v2/authenticate"),
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="DwollaClient"/> class.
        /// </summary>
        public DwollaClient()
            : base(DwollaDescription)
        {
            this.AuthorizationTracker = new TokenManager();
        }

        /// <summary>
        /// Prepares a request for user authorization from the Dwolla authorization server.
        /// </summary>
        /// <param name="scopes">The scopes of authorized access requested.</param>
        public void RequestUserAuthorization(IEnumerable<Scope> scopes)
        {
            RequestUserAuthorization(scopes.Select(s => s.Value));
        }

        /// <summary>
        /// Gets the account balance for the user for the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The account balance.
        /// </returns>
        public decimal AccountBalance(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/balance" + ToQueryString(nvc));
            return GetResponseData<decimal>(request);
        }

        /// <summary>
        /// Gets contacts for the user for the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The contacts.
        /// </returns>
        public IEnumerable<ContactsResult> Contacts(string accessToken, string search = null, IEnumerable<ContactType> types = null, int? limit = null)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (search != null) nvc.Add("search", search);
            if (types != null) nvc.Add("types", string.Join(",", types.Select(t => t.Value)));
            if (limit != null) nvc.Add("limit", limit.Value.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/contacts" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<ContactsResult>>(request);
        }

        /// <summary>
        /// Gets nearby Dwolla spots within the <c>range</c> of the <c>latitude</c> and <c>longitude</c>. 
        /// Half of the <c>limit</c> are returned with closest proximity. The other half of the spots are 
        /// returned as random spots within the <c>range</c>.
        /// </summary>
        /// <param name="clientId">The consumer key for the application.</param>
        /// <param name="clientSecret">The consumer secret for the application.</param>
        /// <param name="latitude">The current latitude.</param>
        /// <param name="longitude">The current longitude.</param>
        /// <param name="range">The range to retrieve spots for in miles. Defaults to 10 miles.</param>
        /// <param name="limit">The number of spots to retrieve. Defaults to 10.</param>
        /// <returns>The nearby Dwolla spots.
        /// </returns>
        public IEnumerable<NearbyResult> Nearby(string clientId, string clientSecret, decimal latitude, decimal longitude, int? range = null, int? limit = null)
        {
            if (String.IsNullOrEmpty(clientId))
                throw new ArgumentNullException("clientId");
            if (String.IsNullOrEmpty(clientSecret))
                throw new ArgumentNullException("clientSecret");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("client_id", clientId);
            nvc.Add("client_secret", clientSecret);
            nvc.Add("latitude", latitude.ToString());
            nvc.Add("longitude", longitude.ToString());
            if (range != null) nvc.Add("range", range.Value.ToString());
            if (limit != null) nvc.Add("limit", limit.Value.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/contacts/nearby" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<NearbyResult>>(request);
        }

        /// <summary>
        /// Registers a new Dwolla user account.
        /// </summary>
        /// <param name="clientId">The consumer key for the application.</param>
        /// <param name="clientSecret">The consumer secret for the application.</param>
        /// <param name="acceptTerms">The indication of acceptance/rejection of the Dwolla terms of service.</param>
        /// <param name="email">The email address for the new Dwolla acount.</param>
        /// <param name="password">The password for the new Dwolla account.</param>
        /// <param name="pin">The pin for the new Dwolla account.</param>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state code.</param>
        /// <param name="zip">The postal code or zip code.</param>
        /// <param name="phone">The primary phone number of the user.</param>
        /// <param name="dateOfBirth">The date of birth of the user.</param>
        /// <param name="address">The first line of the user's address.</param>
        /// <param name="address2">The second line of the user's address.</param>
        /// <param name="type">The account type of the new user.</param>
        /// <param name="organization">The company name for a commercial or non-profit account.</param>
        /// <param name="ein">The federal employer identification number for commercial or non-profit accounts.</param>
        /// <returns>The information about the registered user.</returns>
        public RegisterUserResult RegisterUser(
            string clientId,
            string clientSecret,
            bool acceptTerms,
            string email,
            string password,
            int pin,
            string firstName,
            string lastName,
            string city,
            string state,
            string zip,
            long phone,
            DateTime dateOfBirth,
            string address,
            string address2 = null,
            AccountInformationType type = null,
            string organization = null,
            int? ein = null)
        {

            if (String.IsNullOrEmpty(clientId))
                throw new ArgumentNullException("clientId");
            if (String.IsNullOrEmpty(clientSecret))
                throw new ArgumentNullException("clientSecret");
            if (String.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");
            if (String.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if (String.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstname");
            if (String.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lastName");
            if (String.IsNullOrEmpty(city))
                throw new ArgumentNullException("city");
            if (String.IsNullOrEmpty(state))
                throw new ArgumentNullException("state");
            if (String.IsNullOrEmpty(zip))
                throw new ArgumentNullException("zip");
            if (String.IsNullOrEmpty(address))
                throw new ArgumentNullException("address");
            if (type != AccountInformationType.PERSONAL && (organization == null || ein == null))
                throw new ArgumentException("Organization or EIN field not specified for non-Personal type user");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("client_id", clientId);
            nvc.Add("client_secret", clientSecret);
            nvc.Add("email", email);
            nvc.Add("password", password);
            nvc.Add("pin", pin.ToString());
            nvc.Add("firstName", firstName);
            nvc.Add("lastName", lastName);
            nvc.Add("address", address);
            if (address2 != null) nvc.Add("address2", address2);
            nvc.Add("city", city);
            nvc.Add("state", state);
            nvc.Add("zip", zip);
            nvc.Add("phone", phone.ToString());
            nvc.Add("dateOfBirth", dateOfBirth.ToString("d"));
            if (type != null) nvc.Add("type", type.Value);
            if (organization != null) nvc.Add("organization", organization);
            if (ein != null) nvc.Add("ein", ein.ToString());
            nvc.Add("acceptTerms", acceptTerms.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/register/" + ToQueryString(nvc));
            return GetResponseData<RegisterUserResult>(request);
        }

        /// <summary>
        /// Gets a list of transactions for the user for the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="sinceDate">The earliest date and time for which to retrieve transactions. Defaults to 7 days prior to current date.</param>
        /// <param name="types">The transaction types to retrieve. Defaults to include all transaction types.</param>
        /// <param name="limit">The number of transactions to retreive. Defaults to 10.</param>
        /// <param name="skip">The number of transactions to skip. Defaults to 0.</param>
        /// <returns>The list of transactions.
        /// </returns>
        public IEnumerable<TransactionsResult> TransactionsListing(string accessToken, DateTime? sinceDate = null, IEnumerable<TransactionType> types = null, int? limit = null, int? skip = null)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (sinceDate != null) nvc.Add("sinceDate", sinceDate.Value.ToString("d"));
            if (types != null) nvc.Add("types", string.Join("|", types.Select(t => t.Value)));
            if (limit != null) nvc.Add("limit", limit.Value.ToString());
            if (skip != null) nvc.Add("skip", skip.Value.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<TransactionsResult>>(request);
        }

        /// <summary>
        /// Gets transaction by identifier for the user authorized for the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="transactionId">The transaction identifer of the transaction being requested.</param>
        /// <returns>The transaction.
        /// </returns>
        public IEnumerable<TransactionsResult> TransactionsDetailsById(string accessToken, long transactionId)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            nvc.Add("transactionId", transactionId.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions/" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<TransactionsResult>>(request);
        }

        /// <summary>
        /// Gets transactions stats for the user for the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="types">The types of status to retrieve. Default to include all stats.</param>
        /// <param name="startDate">The starting date and time for which to process transactions stats.</param>
        /// <param name="endDate">The ending date and time for which to process transactions stats.</param>
        /// <returns>The transactions stats.
        /// </returns>
        public TransactionsStatsResult TransactionsStats(string accessToken, IEnumerable<TransactionStatsType> types = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (types != null) nvc.Add("types", string.Join(",", types.Select(t => t.Value)));
            if (startDate != null) nvc.Add("startDate", startDate.Value.ToString("d"));
            if (endDate != null) nvc.Add("endDate", endDate.Value.ToString("d"));

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions/stats" + ToQueryString(nvc));
            return GetResponseData<TransactionsStatsResult>(request);
        }

        /// <summary>
        /// Send funds to a destination for the user associated with the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="pin">The user's PIN associated with their account.</param>
        /// <param name="destinationId">The identification of the user to send funds to.</param>
        /// <param name="destinationType">The type of destination user.</param>
        /// <param name="amount">THe amount of funds to transfer to the destination user.</param>
        /// <param name="facilitatorAmount">The amount of the facilitator fee to override. 
        /// Only applicable if the facilitor fee is enabled. If set to 0, facilitator fee 
        /// is disabled for transaction. Cannot exceet 25% of the <c>amount</c></param>
        /// <param name="assumeCost"> The indication of whether the user will assume the Dwolla fee. 
        /// If false, the destination user will assume the Dwolla fee. Defaults to false.</param>
        /// <param name="notes">The note to attach to the transaction</param>
        /// <returns>The identifier of the successful transaction.</returns>
        public long Send(
            string accessToken,
            int pin,
            string destinationId,
            UserType destinationType = null,
            decimal? amount = null,
            decimal? facilitatorAmount = null,
            bool? assumeCost = null,
            string notes = null
            )
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");
            if (String.IsNullOrEmpty(destinationId))
                throw new ArgumentNullException("destinationId");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (destinationType != null) nvc.Add("destinationType", destinationType.Value);
            if (amount != null) nvc.Add("amount", amount.Value.ToString());
            if (facilitatorAmount != null) nvc.Add("facilitatorAmount", facilitatorAmount.Value.ToString());
            if (assumeCost != null) nvc.Add("assumeCosts", assumeCost.Value.ToString());
            if (notes != null) nvc.Add("notes", notes);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions/send" + ToQueryString(nvc));
            return GetResponseData<long>(request);
        }

        /// <summary>
        /// Gets funds from the source user for the user associated with the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="pin">The user's PIN associated with their account.</param>
        /// <param name="sourceId">The identification of the user to request funds from.</param>
        /// <param name="amount">The amount of funds to request from the source user.</param>
        /// <param name="sourceType">The type of the source user.</param>
        /// <param name="facilitatorAmount">The amount of the facilitator fee to override. 
        /// Only applicable if the faciliator fee featue is enabled. If set to 0, facilitator 
        /// fee is disabled for request. Cannot exceed 25% of the <c>amount</c>.</param>
        /// <param name="notes">The note to attach to the transaction.</param>
        /// <returns>The identifier of the successful request.</returns>
        public long Request(string accessToken, int pin, string sourceId, decimal amount, UserType sourceType = null, decimal? facilitatorAmount = null, string notes = null)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");
            if (String.IsNullOrEmpty(sourceId))
                throw new ArgumentNullException("sourceId");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            nvc.Add("pin", pin.ToString());
            nvc.Add("sourceId", sourceId);
            nvc.Add("amount", amount.ToString());
            if (sourceType != null) nvc.Add("sourceType", sourceType.Value);
            if (facilitatorAmount != null) nvc.Add("facilitatorAmount", facilitatorAmount.Value.ToString());
            if (notes != null) nvc.Add("notes", notes);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions/request" + ToQueryString(nvc));
            return GetResponseData<long>(request);
        }

        /// <summary>
        /// Gets the account information for the user associated with the authorized access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The account information.</returns>
        public AccountInformationResult AccountInformation(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("accessToken");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/users" + ToQueryString(nvc));
            return GetResponseData<AccountInformationResult>(request);
        }

        /// <summary>
        /// Gets the basic information for the Dwolla account associated with the account identifier.
        /// </summary>
        /// <param name="client_id">The consumer key for the application.</param>
        /// <param name="client_secret">The consumer secret for the application.</param>
        /// <param name="accountIdentifier">The Dwolla account identifier or email address of the Dwolla account.</param>
        /// <returns></returns>
        public BasicInformationResult BasicInformation(string client_id, string client_secret, string accountIdentifier)
        {
            if (String.IsNullOrEmpty(client_id))
                throw new ArgumentNullException("clientId");
            if (String.IsNullOrEmpty(client_secret))
                throw new ArgumentNullException("clientSecret");
            if (String.IsNullOrEmpty(accountIdentifier))
                throw new ArgumentNullException("accountIdentifier");

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("client_id", client_id);
            nvc.Add("client_secret", client_secret);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/users/" + accountIdentifier + ToQueryString(nvc));
            return GetResponseData<BasicInformationResult>(request);
        }

        private static string ToQueryString(NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(nvc[key]))));
        }

        private static T GetResponseData<T>(WebRequest request)
        {
            using (var response = request.GetResponse())
            {
                string resultString;
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    resultString = reader.ReadToEnd();
                }

                return Deserialize<T>(resultString);
            }
        }

        private static T Deserialize<T>(string text)
        {
            ResultObject<T> resultObject;
            Console.WriteLine(text);
            try
            {
                resultObject = JsonConvert.DeserializeObject<ResultObject<T>>(text);
            }
            catch (Exception ex)
            {
                throw new DeserializeException(typeof(ResultObject<T>), text, ex);
            }
            if (!resultObject.Success)
            {
                throw new DwollaServiceException(resultObject.Success, resultObject.Message);
            }

            return resultObject.Response;
        }
    }
}
