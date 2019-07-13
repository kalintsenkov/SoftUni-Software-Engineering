namespace MilitaryElite.Exceptions
{
    using System;

    public class InvalidStateException : Exception
    {
        public InvalidStateException()
            : base()
        {
        }

        public InvalidStateException(string message) 
            : base(message)
        {
        }
    }
}
