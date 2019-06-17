using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                var engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                if (engineInfo.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2], out int displacement))
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, engineInfo[2]));
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];

                    engines.Add(new Engine(
                        model,
                        power,
                        displacement,
                        efficiency));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carInfo[0];
                string engineModel = carInfo[1];

                var engine = GetEngine(engines, engineModel);

                if (carInfo.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (carInfo.Length == 3)
                {
                    if(int.TryParse(carInfo[2], out int weight))
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, carInfo[2]));
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];

                    cars.Add(new Car(
                        model,
                        engine,
                        weight,
                        color));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        public static Engine GetEngine(List<Engine> engines, string engineModel) => engines
            .Where(x => x.Model == engineModel)
            .FirstOrDefault();
    }
}
