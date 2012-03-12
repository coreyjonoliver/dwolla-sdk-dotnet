namespace Dwolla.API
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class TransactionsStatsResult
    {
        /// <summary>
        /// Supplies the number of transactions for the specified period.
        /// </summary>
        [JsonProperty("TransactionsCount")]
        public int TransactionsCount { get; internal set; }

        /// <summary>
        /// Supplied the total number of transactions for the specified period.
        /// </summary>
        [JsonProperty("TransactionsTotal")]
        public decimal TransactionsTotal { get; internal set; }
    }
}
