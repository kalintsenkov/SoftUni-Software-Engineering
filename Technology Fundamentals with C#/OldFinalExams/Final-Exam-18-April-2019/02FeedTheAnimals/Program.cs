using System;
using System.Linq;
using System.Collections.Generic;

namespace _02FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var animals = new Dictionary<string, int>();
            var areasWithHungryAnimals = new Dictionary<string, int>();

            while (input != "Last Info")
            {
                var tokens = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if(command == "Add")
                {
                    string animalName = tokens[1];
                    int dailyFoodLimit = int.Parse(tokens[2]);
                    string area = tokens[3];

                    if (!animals.ContainsKey(animalName))
                    {
                        animals.Add(animalName, dailyFoodLimit);

                        if (!areasWithHungryAnimals.ContainsKey(area))
                        {
                            areasWithHungryAnimals[area] = 1;
                        }
                        else
                        {
                            areasWithHungryAnimals[area]++;
                        }
                    }
                    else
                    {
                        animals[animalName] += dailyFoodLimit;
                    }
                }
                else if(command == "Feed")
                {
                    string animalName = tokens[1];
                    int food = int.Parse(tokens[2]);
                    string area = tokens[3];

                    if (animals.ContainsKey(animalName) && areasWithHungryAnimals.ContainsKey(area))
                    {
                        animals[animalName] -= food;

                        if (animals[animalName] <= 0)
                        {
                            animals.Remove(animalName);
                            areasWithHungryAnimals[area]--;
                            Console.WriteLine($"{animalName} was successfully fed");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Animals:");

            foreach (var animal in animals.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var area in areasWithHungryAnimals.OrderByDescending(x => x.Value).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{area.Key} : {area.Value}");
            }
        }
    }
}
