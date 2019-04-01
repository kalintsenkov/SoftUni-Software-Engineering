using System;

namespace _04ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reversedText = string.Empty;

            for (int i = text.Length-1; i >= 0; i--)
            {
                reversedText = reversedText + text[i];
            }
            Console.WriteLine(reversedText);
        }
    }
}
