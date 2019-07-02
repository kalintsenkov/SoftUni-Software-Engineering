namespace P02_CarsSalesman
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var engineFactory = new EngineFactory();
            var carFactory = new CarFactory();
            var carSalesman = new CarSalesman(engineFactory, carFactory);
            var runner = new Runner(carSalesman);

            runner.Start();
        }
    }
}
