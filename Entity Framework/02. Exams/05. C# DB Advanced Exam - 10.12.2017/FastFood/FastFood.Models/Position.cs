namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}