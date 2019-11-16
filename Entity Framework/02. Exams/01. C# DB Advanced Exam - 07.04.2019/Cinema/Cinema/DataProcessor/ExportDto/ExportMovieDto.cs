namespace Cinema.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExportMovieDto
    {
        [JsonProperty("MovieName")]
        public string MovieName { get; set; }

        [JsonProperty("Rating")]
        public string Rating { get; set; }

        [JsonProperty("TotalIncomes")]
        public string TotalIncomes { get; set; }

        [JsonProperty("Customers")]
        public ICollection<ExportCustomerWithMoviesDto> Customers { get; set; }
    }
}