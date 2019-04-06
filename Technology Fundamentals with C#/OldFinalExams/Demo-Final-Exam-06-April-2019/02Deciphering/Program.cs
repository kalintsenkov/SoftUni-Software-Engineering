using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02Deciphering
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string letters = Console.ReadLine();

            string pattern = @"^[d-z{},|#]+$";
            Regex regex = new Regex(pattern);

            StringBuilder decryptedText = new StringBuilder();

            if (regex.IsMatch(input))
            {
                DecryptingText(input, decryptedText);

                var substrings = letters.Split(" ").ToArray();

                var firstSubstring = substrings[0];
                var secondSubstring = substrings[1];

                decryptedText = decryptedText.Replace(firstSubstring, secondSubstring);
            }
            else
            {
                Console.WriteLine($"This is not the book you are looking for.");
                return;
            }

            Console.WriteLine(decryptedText);
        }

        public static void DecryptingText(string input, StringBuilder decryptedText)
        {
            foreach (var character in input)
            {
                char decryptedChar = (char)(character - 3);

                decryptedText.Append(decryptedChar);
            }
        }
    }
}
