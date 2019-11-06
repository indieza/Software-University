namespace CarDealer.DTO
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExportCarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        [JsonProperty("parts")]
        public ICollection<ExportPartDto> Parts { get; set; }
    }
}