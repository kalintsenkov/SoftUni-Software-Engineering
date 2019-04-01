using System;

namespace _05Messeges
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTypings = int.Parse(Console.ReadLine());

            int pressingNumbers = 0;
            int numberOfDigits = 0;
            int mainDigit = 0;
            int offsetOfNumber = 0;
            int letterIndex = 0;
            char character = (char)97;
            string message = string.Empty;

            for (int i = 1; i <= numberOfTypings; i++)
            {
                pressingNumbers = int.Parse(Console.ReadLine());

                numberOfDigits = pressingNumbers.ToString().Length;
                mainDigit = pressingNumbers % 10;
                offsetOfNumber = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offsetOfNumber++;
                }
                letterIndex = offsetOfNumber + numberOfDigits - 1;

                if (mainDigit == 0)
                {
                    character = (char)32;
                }
                else
                {
                    character = (char)(character + letterIndex);
                }
                message = message + character;
                character = (char)97;
            }
            Console.WriteLine(message);
        }
    }
}
