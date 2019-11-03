namespace SoftJail.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"^[0-9 a-zA-Z]+str.$"), Required]
        public string Address { get; set; }

        [ForeignKey("Prisoner"), Required]
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }
    }
}