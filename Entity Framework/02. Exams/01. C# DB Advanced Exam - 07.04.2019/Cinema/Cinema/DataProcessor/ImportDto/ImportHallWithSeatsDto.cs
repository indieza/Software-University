namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportHallWithSeatsDto
    {
        [MinLength(3), MaxLength(20), Required]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        [Range(1, int.MaxValue)]
        public int Seats { get; set; }
    }
}