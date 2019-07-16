namespace VehiclesExtension.Exceptions
{
    using System;

    public class FuelOutOfTankException : Exception
    {
        public FuelOutOfTankException(string message) 
            : base(message)
        {
        }
    }
}
