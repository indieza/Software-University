namespace CarDealer.DTO.Import
{
    using System.Collections.Generic;

    public class ImortCarDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; }
    }
}