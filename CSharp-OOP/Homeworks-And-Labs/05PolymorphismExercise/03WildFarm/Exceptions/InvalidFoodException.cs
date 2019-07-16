namespace WildFarm.Exceptions
{
    using System;

    public class InvalidFoodException : Exception
    {
        public InvalidFoodException(string message) 
            : base(message)
        {
        }
    }
}
