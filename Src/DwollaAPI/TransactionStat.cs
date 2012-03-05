namespace Dwolla.API
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class TransactionStat
    {
        [JsonProperty("TransactionsCount")]
        public int TransactionsCount { get; internal set; }

        [JsonProperty("TransactionsTotal")]
        public decimal TransactionsTotal { get; internal set; }
    }
}
