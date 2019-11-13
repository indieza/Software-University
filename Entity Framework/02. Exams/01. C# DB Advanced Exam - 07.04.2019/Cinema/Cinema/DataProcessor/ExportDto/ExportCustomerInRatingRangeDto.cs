namespace Cinema.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportCustomerInRatingRangeDto
    {
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Balance")]
        public string Balance { get; set; }
    }
}