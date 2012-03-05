namespace Dwolla.API
{
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class Contact
    {
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Image")]
        public string Image { get; internal set; }

        [JsonProperty("Type")]
        [JsonConverter(typeof(ContactTypeConverter))]
        public ContactType Type { get; internal set; }
    }
}
