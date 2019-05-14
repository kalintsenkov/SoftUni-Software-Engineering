using System;
using System.Text;

namespace _06ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length - 1; i++)
            {
                char currentCharacter = text[i];
                char nextCharacter = text[i + 1];

                if (currentCharacter != nextCharacter)
                {
                    sb.Append(currentCharacter);
                }

                if (i == text.Length - 2)
                {
                    sb.Append(nextCharacter);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
