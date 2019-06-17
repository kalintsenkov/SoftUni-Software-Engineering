using System;
using System.Collections.Generic;

namespace _07TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerGreenLight = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            int totalCars = 0;

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    int carsToPass = Math.Min(carsPerGreenLight, cars.Count);

                    for (int i = 1; i <= carsToPass; i++)
                    {
                        string currentCar = cars.Dequeue();
                        Console.WriteLine($"{currentCar} passed!");
                        totalCars++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCars} cars passed the crossroads.");
        }
    }
}
