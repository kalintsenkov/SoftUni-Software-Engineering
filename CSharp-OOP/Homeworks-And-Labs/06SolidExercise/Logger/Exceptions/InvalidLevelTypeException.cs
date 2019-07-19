namespace Logger.Exceptions
{
    using System;

    public class InvalidLevelTypeException : Exception
    {
        private const string ExceptionMessage = "Invalid Level Type!";

        public InvalidLevelTypeException()
            : base(ExceptionMessage)
        {
        }

        public InvalidLevelTypeException(string message) 
            : base(message)
        {
        }
    }
}
