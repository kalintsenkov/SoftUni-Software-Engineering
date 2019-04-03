using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _02ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var keys = Console.ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var validKeys = new List<string>();

            var fixedKeys = new List<string>();

            ValidatingKeys(keys, validKeys);

            for (int i = 0; i < validKeys.Count; i++)
            {
                string currentKey = validKeys[i];
                StringBuilder sb = new StringBuilder();

                if (currentKey.Length == 16)
                {
                    Making16SymbolKey(currentKey, sb);

                    MakingDigits(sb);
                }
                else if (currentKey.Length == 25)
                {
                    Making25SymbolKey(currentKey, sb);

                    MakingDigits(sb);
                }

                fixedKeys.Add(sb.ToString());
            }

            Console.WriteLine(string.Join(", ", fixedKeys));
        }

        private static void ValidatingKeys(List<string> keys, List<string> validKeys)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                string currentKey = keys[i];

                bool isValid = false;

                if (currentKey.Length == 16 || currentKey.Length == 25)
                {
                    for (int j = 0; j < currentKey.Length; j++)
                    {
                        char currentChar = currentKey[j];

                        if (char.IsLetterOrDigit(currentChar))
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                {
                    validKeys.Add(currentKey);
                }
            }
        }

        private static void Making25SymbolKey(string currentKey, StringBuilder sb)
        {
            int counter = 0;

            for (int j = 0; j < currentKey.Length; j++)
            {
                char currentChar = currentKey[j];

                if (counter < 5)
                {
                    currentChar = char.ToUpper(currentChar);
                    sb.Append(currentChar);
                    counter++;
                }
                else if (counter == 5)
                {
                    sb.Append("-");
                    counter = 0;
                    j--;
                }
            }
        }

        private static void Making16SymbolKey(string currentKey, StringBuilder sb)
        {
            int counter = 0;

            for (int j = 0; j < currentKey.Length; j++)
            {
                char currentChar = currentKey[j];

                if (counter < 4)
                {
                    currentChar = char.ToUpper(currentChar);
                    sb.Append(currentChar);
                    counter++;
                }
                else if (counter == 4)
                {
                    sb.Append("-");
                    counter = 0;
                    j--;
                }
            }
        }

        private static void MakingDigits(StringBuilder sb)
        {
            for (int k = 0; k < sb.Length; k++)
            {
                char currentChar = sb[k];

                if (char.IsDigit(currentChar))
                {
                    int digit = int.Parse(currentChar.ToString());
                    digit = Math.Abs(digit - 9);

                    char newDigit = char.Parse(digit.ToString());

                    sb.Replace(currentChar, newDigit, k, 1);
                }
            }
        }
    }
}
