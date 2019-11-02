using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required, MaxLength(50), Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        [Required, Column(TypeName = "VARCHAR(MAX)")]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required, ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}