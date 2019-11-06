namespace CarDealer.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExportCarToyotaDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}