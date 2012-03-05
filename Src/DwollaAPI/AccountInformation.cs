namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class AccountInformation
    {
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Latitude")]
        public decimal Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public decimal Longitude { get; internal set; }

        [JsonProperty("Type")]
        [JsonConverter(typeof(AccountInformationTypeConverter))]
        public AccountInformationType Type { get; internal set; }

        [JsonProperty("City")]
        public string City { get; internal set; }

        [JsonProperty("State")]
        public string State { get; internal set; }  
    }
}
