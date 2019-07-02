namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Runner
    {
        private CarCatalog cars;

        public Runner(CarCatalog cars)
        {
            this.cars = cars;
        }

        public void Start()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.cars.Add(parameters);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragile = this.cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintCars(fragile);
            }
            else
            {
                var flamable = this.cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintCars(flamable);
            }
        }

        private void PrintCars(List<string> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
