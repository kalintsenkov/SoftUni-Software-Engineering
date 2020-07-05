using System;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string reversedInput = string.Empty;

                reversedInput = ReversingInput(input, reversedInput);
                IsItPalindrome(input, reversedInput);

                input = Console.ReadLine();
            }
        }

        private static void IsItPalindrome(string input, string reversedInput)
        {
            if (reversedInput == input)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        private static string ReversingInput(string input, string reversedInput)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedInput += input[i];
            }

            return reversedInput;
        }
    }
}
