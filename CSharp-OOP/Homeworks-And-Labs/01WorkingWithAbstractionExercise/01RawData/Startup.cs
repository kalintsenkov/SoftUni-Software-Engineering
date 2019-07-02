namespace P01_RawData
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var cars = new CarCatalog();
            var runner = new Runner(cars);

            runner.Start();
        }
    }
}
