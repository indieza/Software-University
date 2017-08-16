using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface IStudent : IComparable<IStudent>
    {
        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }
        IReadOnlyDictionary<string, double> MarksByCourseName { get; }
        string UserName { get; }

        void EntrollInCourse(ICourse course);

        void SetMarksInCourse(string courseName, params int[] scores);
    }
}