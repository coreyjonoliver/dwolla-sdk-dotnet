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
