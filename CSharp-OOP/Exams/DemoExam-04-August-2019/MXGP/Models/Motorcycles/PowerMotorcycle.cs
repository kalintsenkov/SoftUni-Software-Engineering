namespace MXGP.Models.Motorcycles
{
    using System;

    using Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 450.0;
        private const int MinHorsePower = 70;
        private const int MaxHorsePower = 100;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
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
