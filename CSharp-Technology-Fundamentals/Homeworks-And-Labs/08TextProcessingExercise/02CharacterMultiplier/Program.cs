using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _02CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ")
                .ToArray();

            string firstWord = words[0];
            string secondWord = words[1];

            int totalSum = CharacterMultiplier(firstWord, secondWord);

            Console.WriteLine(totalSum);
        }

        private static int CharacterMultiplier(string firstWord, string secondWord)
        {
            int totalSum = 0;

            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    int multiply = firstWord[i] * secondWord[i];
                    totalSum += multiply;
                }
            }
            else
            {
                if (firstWord.Length > secondWord.Length)
                {
                    for (int i = 0; i < secondWord.Length; i++)
                    {
                        int multiply = firstWord[i] * secondWord[i];
                        totalSum += multiply;
                    }

                    for (int i = secondWord.Length; i < firstWord.Length; i++)
                    {
                        totalSum += firstWord[i];
                    }
                }
                else if (secondWord.Length > firstWord.Length)
                {
                    for (int i = 0; i < firstWord.Length; i++)
                    {
                        int multiply = firstWord[i] * secondWord[i];
                        totalSum += multiply;
                    }

                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        totalSum += secondWord[i];
                    }
                }
            }

            return totalSum;
        }
    }
}
