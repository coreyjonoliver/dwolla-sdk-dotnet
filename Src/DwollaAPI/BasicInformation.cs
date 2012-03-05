namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class BasicInformation
    {
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Latitude")]
        public decimal Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public decimal Longitude { get; internal set; }
    }
}
