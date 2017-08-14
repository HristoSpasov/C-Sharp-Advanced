namespace SimpleJudje.Exceptions
{
    using System;

    public class CourseNotFoundException : Exception
    {
        private const string CourseNotFoundMessage = "Course not found";

        public CourseNotFoundException()
            : base(CourseNotFoundMessage)
        {
        }

        public CourseNotFoundException(string message)
            : base(message)
        {
        }
    }
}