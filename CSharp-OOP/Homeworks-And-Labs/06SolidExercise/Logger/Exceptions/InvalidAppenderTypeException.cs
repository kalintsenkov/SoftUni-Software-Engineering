namespace Logger.Exceptions
{
    using System;

    public class InvalidAppenderTypeException : Exception
    {
        private const string ExceptionMessage = "Invalid Appender Type!";

        public InvalidAppenderTypeException()
            : base(ExceptionMessage)
        {
        }

        public InvalidAppenderTypeException(string message) 
            : base(message)
        {
        }
    }
}
