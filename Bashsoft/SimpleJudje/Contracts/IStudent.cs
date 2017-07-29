using System;
using System.Collections.Generic;

namespace SimpleJudje.Contracts
{
    public interface IStudent : IComparable<IStudent>
    {
        string UserName { get; }

        IDictionary<string, double> MarksByCourseName { get; }

        IDictionary<string, ICourse> EnrolledCourses { get; }

        void EnrollInCourse(ICourse course);

        void SetMarksInCourse(string courseName, params int[] scores);
    }
}