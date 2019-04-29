using System;

namespace _05PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingCharacter = int.Parse(Console.ReadLine());
            int endingCharacter = int.Parse(Console.ReadLine());

            for (char i = (char)startingCharacter; i <= (char)endingCharacter; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
