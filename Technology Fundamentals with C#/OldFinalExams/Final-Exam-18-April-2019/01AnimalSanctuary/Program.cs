using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01AnimalSanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalWeight = 0;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"^n:(?<animalName>.+)\;t(?<animalKind>.+)\;c\-\-(?<animalCountry>[A-Za-z ]+)$";

                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    string name = regex.Match(input).Groups["animalName"].Value;
                    string kind = regex.Match(input).Groups["animalKind"].Value;
                    string country = regex.Match(input).Groups["animalCountry"].Value;

                    StringBuilder animalName = new StringBuilder();
                    StringBuilder animalKind = new StringBuilder();
                    StringBuilder animalCountry = new StringBuilder();

                    foreach (var character in name)
                    {
                        if (char.IsLetter(character) || char.IsWhiteSpace(character))
                        {
                            animalName.Append(character);
                        }
                        else if (char.IsDigit(character))
                        {
                            int digit = int.Parse(character.ToString());

                            totalWeight += digit;
                        }
                    }

                    foreach (var character in kind)
                    {
                        if (char.IsLetter(character) || char.IsWhiteSpace(character))
                        {
                            animalKind.Append(character);
                        }
                        else if (char.IsDigit(character))
                        {
                            int digit = int.Parse(character.ToString());

                            totalWeight += digit;
                        }
                    }

                    foreach (var character in country)
                    {
                        if (char.IsLetter(character) || char.IsWhiteSpace(character))
                        {
                            animalCountry.Append(character);
                        }
                        else if (char.IsDigit(character))
                        {
                            int digit = int.Parse(character.ToString());

                            totalWeight += digit;
                        }
                    }

                    Console.WriteLine($"{animalName} is a {animalKind} from {animalCountry}");
                }
            }

            Console.WriteLine($"Total weight of animals: {totalWeight}KG");
        }
    }
}
