namespace _01RhombusOfStars
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int rhombusSize = int.Parse(Console.ReadLine());

            PrintUpperSide(rhombusSize);
            PrintLowerSide(rhombusSize);
        }

        private static void PrintLowerSide(int rhombusSize)
        {
            for (int stars = rhombusSize - 1; stars >= 1; stars--)
            {
                PrintRow(stars, rhombusSize);
            }
        }

        private static void PrintUpperSide(int rhombusSize)
        {
            for (int stars = 1; stars <= rhombusSize; stars++)
            {
                PrintRow(stars, rhombusSize);
            }
        }

        private static void PrintRow(int stars, int rhombusSize)
        {
            for (int i = 0; i < rhombusSize - stars; i++)
            {
                Console.Write(" ");
            }

            for (int j = 1; j < stars; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
