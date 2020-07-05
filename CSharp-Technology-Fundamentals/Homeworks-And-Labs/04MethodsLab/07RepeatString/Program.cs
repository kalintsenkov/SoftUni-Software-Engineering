using System;

namespace _07RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            string repeatedText = GetRepeatedText(text, repeats);

            Console.WriteLine(repeatedText);
        }

        static string GetRepeatedText(string text, int repeat)
        {
            string result = string.Empty;

            for (int i = 1; i <= repeat; i++)
            {
                result = result + text;
            }

            return result;
        }
    }
}
