namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SongPerformer
    {
        [ForeignKey("Song"), Required]
        public int SongId { get; set; }

        public Song Song { get; set; }

        [ForeignKey("Performer"), Required]
        public int PerformerId { get; set; }

        public Performer Performer { get; set; }
    }
}