using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using System.Collections.Generic;

namespace SimpleJudje.Models
{
    internal class Course : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoresOnExamTask = 100;

        private string name;
        private readonly Dictionary<string, IStudent> studentsByName;

        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return this.studentsByName; }
        }

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.Name));
                //return;
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}