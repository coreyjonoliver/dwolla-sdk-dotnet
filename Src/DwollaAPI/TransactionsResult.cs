namespace Dwolla.API
{
    using System;
    using Newtonsoft.Json;
    using Converters;

    [JsonObject]
    public class TransactionsResult
    {
        /// <summary>
        /// Supplies the transaction identifier.
        /// </summary>
        [JsonProperty("Id")]
        public string Id { get; internal set; }

        /// <summary>
        /// Supplies the date of the transaction processed.
        /// </summary>
        [JsonProperty("Date")]
        [JsonConverter(typeof(EnUSDateTimeConverter))]
        public DateTime Date { get; internal set; }

        /// <summary>
        /// Supplies the amount of the transaction.
        /// </summary>
        [JsonProperty("Amount")]
        public decimal Amount { get; internal set; }

        /// <summary>
        /// Supplies the destination identifier of the user when type is money sent or withdrawal.
        /// </summary>
        [JsonProperty("DestinationId")]
        public string DestinationId { get; internal set; }

        /// <summary>
        /// Supplies the name of user when type is money sent or withdrawal.
        /// </summary>
        [JsonProperty("DestinationName")]
        public string DestinationName { get; internal set; }

        /// <summary>
        /// Supplies the name of the user when type is money recieved, deposit, or fee.
        /// </summary>
        [JsonProperty("SourceId")]
        public string SourceId { get; internal set; }

        /// <summary>
        /// Supplies the transaction type.
        /// </summary>
        [JsonProperty("SourceName")]
        public string SourceName { get; internal set; }

        /// <summary>
        /// Supplies the user type of the recieving account.
        /// </summary>
        [JsonProperty("Type")]
        [JsonConverter(typeof(TransactionTypeConverter))]
        public TransactionType Type { get; internal set; }

        /// <summary>
        /// Supplies the user type of the recieving account.
        /// </summary>
        [JsonConverter(typeof(UserTypeConverter))]
        [JsonProperty("UserType")]
        public UserType UserType { get; internal set; }

        /// <summary>
        /// Supplies the transaction status.
        /// </summary>
        [JsonProperty("Status")]
        [JsonConverter(typeof(TransactionStatusConverter))]
        public TransactionsStatusResult Status { get; internal set; }

        /// <summary>
        ///  Supplies the expected clearing date of the transaction.
        /// </summary>
        [JsonProperty("ClearingDate")]
        [JsonConverter(typeof(EnUSDateTimeConverter))]
        public DateTime ClearingDate { get; internal set; }
    }
}
