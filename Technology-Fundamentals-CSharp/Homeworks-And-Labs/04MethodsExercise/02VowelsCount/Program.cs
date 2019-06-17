using System;

namespace _02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int result = PrintsCountOfVowels(input);
            Console.WriteLine(result);
        }

        private static int PrintsCountOfVowels(string input)
        {
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u'||
                   input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
