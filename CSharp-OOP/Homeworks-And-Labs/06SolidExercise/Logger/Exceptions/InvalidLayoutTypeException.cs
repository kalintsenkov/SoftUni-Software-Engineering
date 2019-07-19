namespace Logger.Exceptions
{
    using System;

    public class InvalidLayoutTypeException : Exception
    {
        private const string ExceptionMessage = "Invalid Layout Type!";

        public InvalidLayoutTypeException()
            : base(ExceptionMessage)
        {
        }

        public InvalidLayoutTypeException(string message) 
            : base(message)
        {
        }
    }
}
