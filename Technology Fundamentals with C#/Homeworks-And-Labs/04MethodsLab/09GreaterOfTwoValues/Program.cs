using System;

namespace _09GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();

            if (valueType == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());

                int result = MaxInt(firstNumber, secondNumber);

                Console.WriteLine(result);
            }
            else if (valueType == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());

                char result = MaxChar(firstChar, secondChar);

                Console.WriteLine(result);
            }
            else if (valueType == "string")
            {
                string firstText = Console.ReadLine();
                string secondText = Console.ReadLine();

                string result = MaxString(firstText, secondText);

                Console.WriteLine(result);
            }


        }

        private static string MaxString(string firstText, string secondText)
        {
            if (firstText.CompareTo(secondText) >= 0)
            {
                return firstText;
            }
            else
            {
                return secondText;
            }
        }

        static char MaxChar(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
            else
            {
                return secondChar;
            }
        }

        static int MaxInt(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }
    }
}
