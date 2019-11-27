namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}