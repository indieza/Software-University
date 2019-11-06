namespace CarDealer.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ImortCarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; }
    }
}