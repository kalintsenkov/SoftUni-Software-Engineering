namespace Ferrari.Models
{
    using Contracts;

    public abstract class Car : ICar
    {
        protected Car(string driverName)
        {
            this.DriverName = driverName;
        }

        public abstract string Model { get; }

        public string DriverName { get; private set; }

        public string SpeedUp()
        {
            return "Gas!";
        }

        public string Stop()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Stop()}/{this.SpeedUp()}/{this.DriverName}";
        }
    }
}
