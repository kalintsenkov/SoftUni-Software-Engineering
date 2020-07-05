using System;

namespace _12EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int evenNumber = int.Parse(Console.ReadLine());

            while (evenNumber % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                evenNumber = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(evenNumber)}");
        }
    }
}
