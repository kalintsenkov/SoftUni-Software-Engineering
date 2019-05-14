using System;
using System.Text;

namespace _05Digits_LettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string others = string.Empty;

            foreach (char character in text)
            {
                if (char.IsDigit(character))
                {
                    digits += character;
                }
                else if (char.IsLetter(character))
                {
                    letters += character;
                }
                else
                {
                    others += character;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
