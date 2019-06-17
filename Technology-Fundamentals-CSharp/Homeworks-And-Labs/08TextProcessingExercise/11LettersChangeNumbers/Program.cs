using System;
using System.Text;
using System.Linq;

namespace _11LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder digitAsNumber = new StringBuilder();

            decimal totalSum = 0;

            var tokens = input
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //taking every string in list
            for (int j = 0; j < tokens.Count; j++)
            {
                string currentToken = tokens[j];

                //taking every digit in current string
                for (int k = 0; k < currentToken.Length; k++)
                {
                    char currentSymbol = currentToken[k];

                    if (char.IsDigit(currentSymbol))
                    {
                        digitAsNumber.Append(currentSymbol);
                    }
                }

                decimal number = decimal.Parse(digitAsNumber.ToString());

                //letter before number
                for (int k = 0; k < currentToken.Length; k++)
                {
                    char currentSymbol = currentToken[k];

                    if (char.IsLetter(currentSymbol) && char.IsUpper(currentSymbol))
                    {
                        int letterPostion = currentSymbol - 65 + 1;
                        number /= letterPostion;
                        break;
                    }
                    else if (char.IsLetter(currentSymbol) && char.IsLower(currentSymbol))
                    {
                        int letterPostion = currentSymbol - 97 + 1;
                        number *= letterPostion;
                        break;
                    }
                }

                int lastIndexOfNumber = currentToken.LastIndexOf(digitAsNumber.ToString());

                //letter after number
                for (int k = lastIndexOfNumber; k < currentToken.Length; k++)
                {
                    char currentSymbol = currentToken[k];

                    if (char.IsLetter(currentSymbol) && char.IsUpper(currentSymbol))
                    {
                        int letterPostion = currentSymbol - 65 + 1;
                        number -= letterPostion;
                        break;
                    }
                    else if (char.IsLetter(currentSymbol) && char.IsLower(currentSymbol))
                    {
                        int letterPostion = currentSymbol - 97 + 1;
                        number += letterPostion;
                        break;
                    }
                }

                totalSum += number;

                digitAsNumber.Clear();
            }


            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
