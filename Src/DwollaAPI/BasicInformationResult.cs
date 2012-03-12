namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class BasicInformationResult
    {
        /// <summary>
        /// Supplies the Dwolla account identifier.
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        /// <summary>
        /// Supplies the name of the Dwolla account.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }
        
        /// <summary>
        /// Supplies the latitude of the Dwolla account if it is a commercial account.
        /// </summary>
        [JsonProperty("Latitude")]
        public decimal Latitude { get; internal set; }

        /// <summary>
        /// Supplies the longitude of the Dwolla account if it is a commercial account.
        /// </summary>
        [JsonProperty("Longitude")]
        public decimal Longitude { get; internal set; }
    }
}
