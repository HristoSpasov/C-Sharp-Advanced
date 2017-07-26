using System;

namespace SimpleJudje.Exceptions
{
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