using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Dwolla.API.DwollaAPI
{
    public class FundingSourcesListingResult
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Verified")]
        public bool Verified { get; set; }

        [JsonProperty("ProcessingType")]
        public BankProcessingType BankProcessingType { get; set; }

        [JsonProperty("Balance")]
        public decimal? Balance { get; set; }
    }
}
