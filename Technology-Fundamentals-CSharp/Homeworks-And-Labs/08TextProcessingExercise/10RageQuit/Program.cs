using System;
using System.Collections.Generic;
using System.Text;

namespace _10RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            string replacement = string.Empty;
            List<char> uniqueSymbols = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                string digitAsString = string.Empty;

                if (char.IsDigit(symbol))
                {
                    for (int j = i; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            digitAsString += input[j];
                        }
                        else
                        {
                            break;
                        }
                    }

                    int repeatTimes = int.Parse(digitAsString);

                    replacement = replacement.ToUpper();

                    for (int j = 1; j <= repeatTimes; j++)
                    {
                        sb.Append(replacement);
                    }

                    if (repeatTimes > 0)
                    {
                        for (int index = 0; index < replacement.Length; index++)
                        {
                            char currentSymbol = replacement[index];

                            if (!uniqueSymbols.Contains(currentSymbol))
                            {
                                uniqueSymbols.Add(currentSymbol);
                            }
                        }
                    }

                    replacement = string.Empty;
                }
                else
                {
                    replacement += symbol;
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(sb);
        }
    }
}
