using System;

namespace P04ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                Console.Write($"{elements[i]} ");
            }
        }
    }
}
