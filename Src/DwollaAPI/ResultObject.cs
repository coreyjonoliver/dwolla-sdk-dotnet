namespace Dwolla.API
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptOut)]
    internal class ResultObject<T>
    {
        [JsonProperty("Success")]
        public bool Success { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Response")]
        public T Response { get; internal set; }
    }
}
