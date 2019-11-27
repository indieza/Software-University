using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [Range(15, 80), Required]
        public int Age { get; set; }

        [ForeignKey(nameof(Position)), Required]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}