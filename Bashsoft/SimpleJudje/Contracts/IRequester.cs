namespace SimpleJudje.Contracts
{
    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string userName);

        void GetAllStudentsFromCourse(string courseName);
    }
}