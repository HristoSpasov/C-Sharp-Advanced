namespace SimpleJudje.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SimpleJudje.Contracts;
    using SimpleJudje.Exceptions;

    public class Student : IStudent, IComparable<IStudent>
    {
        private readonly IDictionary<string, ICourse> enrolledCourses;
        private readonly IDictionary<string, double> marksByCourseName;
        private string userName;

        public Student(string userName)
        {
            this.userName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // throw new ArgumentException(nameof(this.userName), ExceptionMessages.NullOrEmptyValue);
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public IDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public IDictionary<string, ICourse> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        public override string ToString()
        {
            return this.UserName;
        }

        public int CompareTo(IStudent other)
        {
            return string.Compare(this.UserName, other.UserName, StringComparison.OrdinalIgnoreCase);
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() /
                                            (double)(Course.NumberOfTasksOnExam * Course.MaxScoresOnExamTask);
            double mark = (percentageOfSolvedExam * 4) + 2;
            return mark;
        }
    }
}