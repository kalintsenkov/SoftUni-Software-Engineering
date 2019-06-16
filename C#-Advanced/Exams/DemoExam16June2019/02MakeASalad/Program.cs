using System;
using System.Linq;
using System.Collections.Generic;

namespace _02MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegetablesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var caloriesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var saladCalories = new Stack<int>(caloriesInput);
            var vegetables = new Queue<string>(vegetablesInput);

            var salads = new Queue<int>();

            while (saladCalories.Any() && vegetables.Any())
            {
                int currentCalorie = saladCalories.Peek();

                while (currentCalorie > 0 && vegetables.Any())
                {
                    string currentVegetable = vegetables.Dequeue();

                    if (currentVegetable == "tomato")
                    {
                        currentCalorie -= 80;
                    }
                    else if (currentVegetable == "carrot")
                    {
                        currentCalorie -= 136;
                    }
                    else if (currentVegetable == "lettuce")
                    {
                        currentCalorie -= 109;
                    }
                    else if (currentVegetable == "potato")
                    {
                        currentCalorie -= 215;
                    }
                }

                salads.Enqueue(saladCalories.Pop());
            }

            Console.WriteLine(string.Join(" ", salads));

            if (saladCalories.Any())
            {
                Console.WriteLine(string.Join(" ", saladCalories));
            }
            else if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
