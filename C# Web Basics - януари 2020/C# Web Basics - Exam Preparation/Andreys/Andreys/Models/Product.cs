namespace Andreys.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20), Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        public GenderType Gender { get; set; }
    }
}