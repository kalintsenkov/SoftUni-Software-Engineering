using System;

namespace _10MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int sumOfEvenNumber = GetSumOfEvenNumbers(input);
            int sumOfOddNumbers = GetSumOfOddNumber(input);

            int result = GetMultipleOfEvenAndOdds(sumOfEvenNumber, sumOfOddNumbers);

            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int evenNumbers, int oddNumbers)
        {
            int result = evenNumbers * oddNumbers;
            return result;
        }

        private static int GetSumOfOddNumber(int number)
        {
            int sumOfOdd = 0;
            
            while (number != 0)
            {
                int currentNumber = number % 10;
                number = number / 10;

                if (currentNumber % 2 == 0)
                {
                    sumOfOdd += currentNumber;
                }

            }

            return sumOfOdd;
        }

        private static int GetSumOfEvenNumbers(int number)
        {
            int sumOfEven = 0;

            while (number != 0)
            {
                int currentNumber = number % 10;
                number = number / 10;

                if (currentNumber % 2 != 0)
                {
                    sumOfEven += currentNumber;
                }

            }

            return sumOfEven;
        }
    }
}
