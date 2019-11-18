namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameTag
    {
        [ForeignKey(nameof(Game)), Required]
        public int GameId { get; set; }

        public Game Game { get; set; }

        [ForeignKey(nameof(Tag)), Required]
        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}