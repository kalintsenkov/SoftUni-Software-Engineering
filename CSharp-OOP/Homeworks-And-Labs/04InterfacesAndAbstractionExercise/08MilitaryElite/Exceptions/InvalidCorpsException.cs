namespace MilitaryElite.Exceptions
{
    using System;

    public class InvalidCorpsException : Exception
    {
        public InvalidCorpsException()
            : base()
        {
        }

        public InvalidCorpsException(string message) 
            : base(message)
        {
        }
    }
}
