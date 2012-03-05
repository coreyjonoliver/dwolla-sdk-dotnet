namespace Dwolla.API
{
    using System;
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class Transaction
    {
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        [JsonProperty("Date")]
        [JsonConverter(typeof(EnUSDateTimeConverter))]
        public DateTime Date { get; internal set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; internal set; }

        [JsonProperty("DestinationId")]
        public string DestinationId { get; internal set; }

        [JsonProperty("DestinationName")]
        public string DestinationName { get; internal set; }

        [JsonProperty("SourceId")]
        public string SourceId { get; internal set; }

        [JsonProperty("SourceName")]
        public string SourceName { get; internal set; }

        [JsonProperty("Type")]
        [JsonConverter(typeof(TransactionTypeConverter))]
        public TransactionType Type { get; internal set; }

        [JsonConverter(typeof(UserTypeConverter))]
        [JsonProperty("UserType")]
        public UserType UserType { get; internal set; }

        [JsonProperty("Status")]
        [JsonConverter(typeof(TransactionStatusConverter))]
        public TransactionStatus Status { get; internal set; }

        [JsonProperty("ClearingDate")]
        [JsonConverter(typeof(EnUSDateTimeConverter))]
        public DateTime ClearingDate { get; internal set; }
    }
}
