namespace CarManufacturer
{
    public class Engine
    {
        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cupicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cupicCapacity;
        }
    }
}
