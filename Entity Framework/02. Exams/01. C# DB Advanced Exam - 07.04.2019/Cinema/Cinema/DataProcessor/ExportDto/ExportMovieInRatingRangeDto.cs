namespace Cinema.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExportMovieInRatingRangeDto
    {
        [JsonProperty(PropertyName = "MovieName")]
        public string MovieName { get; set; }

        [JsonProperty(PropertyName = "Rating")]
        public string Raiting { get; set; }

        [JsonProperty(PropertyName = "TotalIncomes")]
        public string TotalIncomes { get; set; }

        [JsonProperty(PropertyName = "Customers")]
        public ICollection<ExportCustomerInRatingRangeDto> Customers { get; set; }
    }
}