namespace SimpleJudje.Exceptions
{
    using System;

    public class InvalidTakeQuantityParameter : Exception
    {
        private const string InvalidTake = "Unable to parse {0}. Take quantity should be 'all' or integer";

        public InvalidTakeQuantityParameter(string takeString)
            : base(string.Format(InvalidTake, takeString))
        {
        }
    }
}