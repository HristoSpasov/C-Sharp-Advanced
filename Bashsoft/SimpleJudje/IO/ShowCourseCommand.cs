using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;

namespace SimpleJudje.IO
{
    public class ShowCourseCommand : Command, IExecutable
    {
        public ShowCourseCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar) : base(input, data, judge, repository, inputOutputManagar)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.Repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}