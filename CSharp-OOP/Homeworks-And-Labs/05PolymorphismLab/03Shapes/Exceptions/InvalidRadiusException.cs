namespace Shapes
{
    using System;

    public class InvalidRadiusException : Exception
    {
        private const string ExceptionMessage = "Radius must be a positive number!";

        public InvalidRadiusException() 
            : base(ExceptionMessage)
        {
        }
    }
}
