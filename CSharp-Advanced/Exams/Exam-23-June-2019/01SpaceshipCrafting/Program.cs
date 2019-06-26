using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01
{
    public class Program
    {
        public static void Main()
        {
            var liquidsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var itemsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int glassCount = 0;
            int aluminiumCount = 0;
            int lithiumCount = 0;
            int carbonCount = 0;

            var liquids = new Queue<int>(liquidsInput);
            var items = new Stack<int>(itemsInput);

            while (liquids.Any() && items.Any())
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = items.Pop();

                if (currentLiquid + currentItem == 25) // Glass
                {
                    glassCount++;
                }
                else if (currentLiquid + currentItem == 50) // Aluminium
                {
                    aluminiumCount++;
                }
                else if (currentLiquid + currentItem == 75) // Lithium
                {
                    lithiumCount++;
                }
                else if (currentLiquid + currentItem == 100) // Carbon fiber
                {
                    carbonCount++;
                }
                else
                {
                    items.Push(currentItem + 3);
                }
            }

            string result = PrintOutput(
                glassCount,
                aluminiumCount,
                lithiumCount,
                carbonCount,
                liquids,
                items);

            Console.WriteLine(result);
        }

        private static string PrintOutput(int glassCount, int aluminiumCount, int lithiumCount, int carbonCount, Queue<int> liquids, Stack<int> items)
        {
            var result = new StringBuilder();

            if (glassCount > 0
                && aluminiumCount > 0
                && lithiumCount > 0
                && carbonCount > 0)
            {
                result.AppendLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                result.AppendLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Any())
            {
                result.AppendLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                result.AppendLine("Liquids left: none");
            }

            if (items.Any())
            {
                result.AppendLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                result.AppendLine("Physical items left: none");
            }

            result.AppendLine($"Aluminium: {aluminiumCount}");
            result.AppendLine($"Carbon fiber: {carbonCount}");
            result.AppendLine($"Glass: {glassCount}");
            result.AppendLine($"Lithium: {lithiumCount}");

            return result.ToString().TrimEnd();
        }
    }
}
