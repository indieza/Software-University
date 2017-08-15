using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        private const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        public CourseNotFoundException() : base(NotEnrolledInCourse)
        {
        }

        public CourseNotFoundException(string message) : base(message)
        {
        }
    }
}