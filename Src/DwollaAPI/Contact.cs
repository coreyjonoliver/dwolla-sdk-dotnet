namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class Contact
    {
        /// <summary>
        /// Supplies the contact identifier.
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        /// <summary>
        /// Supplies the contact name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Supplies the url for the contact image.
        /// </summary>
        [JsonProperty("Image")]
        public string Image { get; internal set; }


        /// <summary>
        /// Supplies the contact type.
        /// </summary>
        [JsonProperty("Type")]
        [JsonConverter(typeof(ContactTypeConverter))]
        public ContactType Type { get; internal set; }
    }
}
