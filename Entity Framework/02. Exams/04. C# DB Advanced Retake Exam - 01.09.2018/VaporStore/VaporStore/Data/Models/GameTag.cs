namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameTag
    {
        [Required, ForeignKey("Game")]
        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required, ForeignKey("Tag")]
        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}