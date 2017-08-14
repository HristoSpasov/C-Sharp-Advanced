﻿namespace SimpleJudje.IO
{
    using SimpleJudje.Attributes;
    using SimpleJudje.Contracts;
    using SimpleJudje.Exceptions;

    [Alias("show")]
    public class ShowCourseCommand : Command, IExecutable
    {
        [Inject]
        private readonly IDatabase repository;

        public ShowCourseCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}