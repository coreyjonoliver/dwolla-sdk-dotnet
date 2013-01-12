using Newtonsoft.Json;

namespace DwollaApi.Dwolla
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