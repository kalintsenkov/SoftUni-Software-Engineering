using System;
using System.Collections.Generic;
using System.Linq;

namespace _01TrojanInvasion
{
    public class Program
    {
        public static void Main()
        {
            int waves = int.Parse(Console.ReadLine());

            int[] spartanNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var spartanPlates = new Queue<int>(spartanNumbers);
            var trojanWarriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                int[] trojanNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                AddWarriors(trojanWarriors, trojanNumbers);

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    spartanPlates.Enqueue(extraPlate);
                }

                while (spartanPlates.Any() && trojanWarriors.Any())
                {
                    int currentPlate = spartanPlates.Dequeue();
                    int currentWarrior = trojanWarriors.Pop();

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;

                        if (currentWarrior > 0)
                        {
                            trojanWarriors.Push(currentWarrior);
                        }
                    }
                    else if (currentPlate > currentWarrior)
                    {
                        currentPlate -= currentWarrior;

                        if (currentPlate > 0)
                        {
                            ChangePlateValue(spartanPlates, currentPlate);
                        }
                    }
                }

                if (spartanPlates.Count == 0)
                {
                    break;
                }
            }

            if (spartanPlates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", spartanPlates)}");
            }
            else if (trojanWarriors.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", trojanWarriors)}");
            }
        }

        private static void AddWarriors(Stack<int> trojanWarriors, int[] trojanNumbers)
        {
            foreach (var warrior in trojanNumbers)
            {
                trojanWarriors.Push(warrior);
            }
        }

        private static void ChangePlateValue(Queue<int> spartanPlates, int currentPlate)
        {
            var additionalPlate = new Queue<int>(spartanPlates);

            while (spartanPlates.Any())
            {
                spartanPlates.Dequeue();
            }

            spartanPlates.Enqueue(currentPlate);

            foreach (var plate in additionalPlate)
            {
                spartanPlates.Enqueue(plate);
            }
        }
    }
}
