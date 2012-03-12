namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;
    using System.Collections.Generic;

    [JsonObject]
    public class NearbyResult
    {
        /// <summary>
        /// Supplies the Dwolla account identifier.
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        /// <summary>
        /// Supplies the company name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Supplies the latitude of the Dwolla spot.
        /// </summary>
        [JsonProperty("Latitude")]
        public decimal Latitude { get; internal set; }

        /// <summary>
        /// Supplies the longitude of the Dwolla spot.
        /// </summary>
        [JsonProperty("Longitude")]
        public decimal Longitude { get; internal set; }

        /// <summary>
        /// Supplies the address of the Dwolla spot.
        /// </summary>
        [JsonProperty("Address")]
        public string Address { get; internal set; }

        /// <summary>
        /// Supplies the city.
        /// </summary>
        [JsonProperty("City")]
        public string City { get; internal set; }

        /// <summary>
        /// Supplies the state.
        /// </summary>
        [JsonProperty("State")]
        public string State { get; internal set; }

        /// <summary>
        /// Supplies the zip or postal code.
        /// </summary>
        [JsonProperty("PostalCode")]
        public string PostalCode { get; internal set; }

        /// <summary>
        /// Supplies all other results that share the same latitude and longitude. Will be own <c>Id</c> if no other spots share geo information.
        /// </summary>
        [JsonProperty("Group")]
        [JsonConverter(typeof(GroupConverter))]
        public IEnumerable<string> Group { get; internal set; }

        /// <summary>
        /// Supplies the url for the spot image.
        /// </summary>
        [JsonProperty("Image")]
        public string Image { get; internal set; }  
    }
}
