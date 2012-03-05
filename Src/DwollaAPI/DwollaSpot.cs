namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;
    using System.Collections.Generic;

    [JsonObject]
    public class DwollaSpot
    {
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Latitude")]
        public decimal Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public decimal Longitude { get; internal set; }

        [JsonProperty("Address")]
        public string Address { get; internal set; }

        [JsonProperty("City")]
        public string City { get; internal set; }

        [JsonProperty("State")]
        public string State { get; internal set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; internal set; }

        [JsonProperty("Group")]
        [JsonConverter(typeof(GroupConverter))]
        public IEnumerable<string> Group { get; internal set; }

        [JsonProperty("Image")]
        public string Image { get; internal set; }  
    }
}
