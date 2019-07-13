namespace Shapes
{
    using System;

    public class InvalidSideException : Exception
    {
        public InvalidSideException(string message)
            : base(message)
        {
        }
    }
}
