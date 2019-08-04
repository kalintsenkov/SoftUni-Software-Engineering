namespace MXGP.Models.Motorcycles
{
    using System;

    using Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 125.0;
        private const int MinHorsePower = 50;
        private const int MaxHorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, InitialCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessages.InvalidHorsePower, 
                            value));
                }

                this.horsePower = value;
            }
        }
    }
}
