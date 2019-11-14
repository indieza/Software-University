namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VaporStore.Data.Models.Enums;

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$"), Required]
        public string Number { get; set; }

        [RegularExpression(@"^[0-9]{3}$"), Required]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [ForeignKey("User"), Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}