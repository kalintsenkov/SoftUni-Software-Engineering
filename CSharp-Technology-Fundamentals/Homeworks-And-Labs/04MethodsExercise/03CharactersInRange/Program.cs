using System;

namespace _03CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintsCharactersInRange(firstChar, secondChar);
        }

        private static void PrintsCharactersInRange(char start, char end)
        {
            if (start <= end)
            {
                for (char i = (char)(start + 1); i < end; i++)
                {
                    Console.Write($"{i} ");
                }
            }
            else
            {
                for (char i = (char)(end + 1); i < start; i++)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
