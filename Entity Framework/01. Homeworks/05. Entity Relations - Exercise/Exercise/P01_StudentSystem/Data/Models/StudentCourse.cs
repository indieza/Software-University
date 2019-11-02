using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        [Required, ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required, ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}