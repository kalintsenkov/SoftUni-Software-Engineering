using System;

namespace P01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] people = new int[n];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;

            for (int i = 0; i < people.Length; i++)
            {
                Console.Write($"{people[i]} ");
                sum = sum + people[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
