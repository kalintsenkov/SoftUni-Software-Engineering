namespace VehiclesExtension.Exceptions
{
    using System;

    public class NegativeFuelException : Exception
    {
        private const string ExceptionMessage = "Fuel must be a positive number";

        public NegativeFuelException() 
            : base(ExceptionMessage)
        {
        }
    }
}
