using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"^(?<peakName>[A-Za-z0-9!@#$?]+)\=(?<length>[\d]+)\<\<(?<geoHashCode>[\w]+)$";

            while (input != "Last note")
            {
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    string peakName = regex.Match(input).Groups["peakName"].Value;
                    int length = int.Parse(regex.Match(input).Groups["length"].Value);
                    string geoHashCode = regex.Match(input).Groups["geoHashCode"].Value;

                    StringBuilder mountainName = new StringBuilder();

                    if (geoHashCode.Length == length)
                    {
                        foreach (var symbol in peakName)
                        {
                            if (char.IsLetterOrDigit(symbol))
                            {
                                mountainName.Append(symbol);
                            }
                        }

                        Console.WriteLine($"Coordinates found! {mountainName.ToString()} -> {geoHashCode}");
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
