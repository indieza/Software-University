namespace Cinema.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportCustomerWithTicketDto
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Balance")]
        public string Balance { get; set; }
    }
}