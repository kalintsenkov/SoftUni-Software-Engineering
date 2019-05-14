using System;
using System.Text;

namespace _03Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToRemove = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(textToRemove))
            {
                text = text.Replace(textToRemove, string.Empty);
            }

            Console.WriteLine(text);
        }
    }
}
