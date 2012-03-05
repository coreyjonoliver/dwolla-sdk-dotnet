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

        public void RequestUserAuthorization(IEnumerable<Scope> scopes)
        {
            RequestUserAuthorization(scopes.Select(s => s.Value));
        }

        public decimal AccountBalance(string accessToken)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/balance" + ToQueryString(nvc));
            return GetResponseData<decimal>(request);
        }

        public IEnumerable<Contact> Contacts(string accessToken, string search = null, IEnumerable<ContactType> types = null, int? limit = null)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (search != null) nvc.Add("search", search);
            if (types != null) nvc.Add("types", string.Join(",", types.Select(t => t.Value)));
            if (limit != null) nvc.Add("limit", limit.Value.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/contacts" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<Contact>>(request);
        }

        public IEnumerable<DwollaSpot> Nearby(string clientId, string clientSecret, decimal latitude, decimal longitude, int? range = null, int? limit = null)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("client_id", clientId);
            nvc.Add("client_secret", clientSecret);
            nvc.Add("latitude", latitude.ToString());
            nvc.Add("longitude", longitude.ToString());
            if (range != null) nvc.Add("range", range.Value.ToString());
            if (limit != null) nvc.Add("limit", limit.Value.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/contacts/nearby" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<DwollaSpot>>(request);
        }

        public RegisterUserResponse RegisterUser(
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
            // currently returns a 405 error
            if (type != AccountInformationType.PERSONAL && (organization == null || ein == null))
                throw new ArgumentException("Organization or EIN field not specified for non-Personal type user");
            else
            {
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
                return GetResponseData<RegisterUserResponse>(request);
            }
        }

        public IEnumerable<Transaction> TransactionsListing(string accessToken, DateTime? sinceDate = null, IEnumerable<TransactionType> types = null, int? limit = null, int? skip = null)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (sinceDate != null) nvc.Add("sinceDate", sinceDate.Value.ToString("d"));
            if (types != null) nvc.Add("types", string.Join("|", types.Select(t => t.Value)));
            if (limit != null) nvc.Add("limit", limit.Value.ToString());
            if (skip != null) nvc.Add("skip", skip.Value.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<Transaction>>(request);
        }

        public IEnumerable<Transaction> TransactionsDetailsById(string accessToken, long transactionId)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            nvc.Add("transactionId", transactionId.ToString());

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions/" + ToQueryString(nvc));
            return GetResponseData<IEnumerable<Transaction>>(request);
        }

        public TransactionStat TransactionsStats(string accessToken, IEnumerable<TransactionStatType> types = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);
            if (types != null) nvc.Add("types", string.Join(",", types.Select(t => t.Value)));
            if (startDate != null) nvc.Add("startDate", startDate.Value.ToString("d"));
            if (endDate != null) nvc.Add("endDate", endDate.Value.ToString("d"));

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/transactions/stats" + ToQueryString(nvc));
            return GetResponseData<TransactionStat>(request);
        }

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

        public long Request(string accessToken, int pin, string sourceId, decimal amount, UserType sourceType = null, decimal? facilitatorAmount = null, string notes = null)
        {
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

        public AccountInformation AccountInformation(string accessToken)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("oauth_token", accessToken);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/users" + ToQueryString(nvc));
            return GetResponseData<AccountInformation>(request);
        }

        public BasicInformation BasicInformation(string client_id, string client_secret, string accountIdentifier)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("accountIdentifier", accountIdentifier);
            nvc.Add("client_id", client_id);
            nvc.Add("client_secret", client_secret);

            var request = WebRequest.Create("https://www.dwolla.com/oauth/rest/users" + ToQueryString(nvc));
            return GetResponseData<BasicInformation>(request);
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
