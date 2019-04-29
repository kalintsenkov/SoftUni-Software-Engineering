using System;

namespace _10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int originalValue = pokePower;
            int targetCounter = 0;

            while (pokePower >= distance)
            {
                pokePower = pokePower - distance;
                targetCounter++;

                if (pokePower == originalValue * 0.50 && exhaustionFactor != 0)
                {
                    pokePower = pokePower / exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(targetCounter);
        }
    }
}
