namespace Dwolla.API
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptOut)]
    internal class ResultObject<T>
    {
        /// <summary>
        /// Supplies whether the request was successful.
        /// </summary>
        [JsonProperty("Success")]
        public bool Success { get; internal set; }

        /// <summary>
        /// Supplies the message.
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; internal set; }

        /// <summary>
        /// Supplies the response.
        /// </summary>
        [JsonProperty("Response")]
        public T Response { get; internal set; }
    }
}
