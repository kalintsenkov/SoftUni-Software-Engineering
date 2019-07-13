namespace MilitaryElite.Exceptions
{
    using System;

    public class InvalidMissionException : Exception
    {
        public InvalidMissionException()
        {
        }

        public InvalidMissionException(string message) 
            : base(message)
        {
        }
    }
}
