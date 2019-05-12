using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"^(?<firstSymbol>[#$%*&]+)(?<name>[A-Za-z]+)(?<secondSymbol>[#$%*&]+)\=(?<length>[\d]+)\!\!(?<geoHashCode>.+)$";

            while (true)
            {
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    string firstSymbol = regex.Match(input).Groups["firstSymbol"].Value;
                    string secondSymbol = regex.Match(input).Groups["secondSymbol"].Value;
                    string racerName = regex.Match(input).Groups["name"].Value;
                    int length = int.Parse(regex.Match(input).Groups["length"].Value);
                    string encryptedCode = regex.Match(input).Groups["geoHashCode"].Value;

                    if(firstSymbol == secondSymbol && encryptedCode.Length == length)
                    {
                        StringBuilder decryptedCode = new StringBuilder();

                        foreach (var character in encryptedCode)
                        {
                            char decryptedCharacter = (char)(character + length);
                            decryptedCode.Append(decryptedCharacter);
                        }

                        Console.WriteLine($"Coordinates found! {racerName} -> {decryptedCode}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
