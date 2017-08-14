namespace SimpleJudje
{
    public static class ExceptionMessages
    {
        //// public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size!";

        //// public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public const string UnableToGoHigherInPartitionHierarchy = "Root folder reached!";

        public const string UnableToParseNumber = "Traverse depth must be integer value!";

        public const string InvalidStudentsFIlter = "The given filter is not one of the following: excellent/average/poor!";

        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";

        public const string InvalidTakeCommand = "The take command expected does not match the format wanted!";

        public const string InvalidTakeQuantityParameter = "Quantity should be integer!";

        public const string DataAlreadyInitialisedException = "Data already initialised!";

        public const string DataNotInitialisedException = "Data not initialised!";

        public const string InvalidScore = "Invalid score!";

        public const string InvalidNumberOfScores = "Invalid number of scores for the given course is greater than the possible!";

        public const string NotEnrolledInCourse = "Not enrolled in course!";

        public const string StudentAlreadyEnrolledInGivenCourse = "Student already enrolled in course!";

        public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";
    }
}