using System;
using System.Linq;
using System.Collections.Generic;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                Instructions(numbers, tokens, command);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Instructions(List<int> numbers, string[] tokens, string command)
        {
            if (command == "Change")
            {
                int paintingNumber = int.Parse(tokens[1]);
                int changedNumber = int.Parse(tokens[2]);

                int indexOfPaintingNumber = numbers.IndexOf(paintingNumber);

                if (numbers.Contains(paintingNumber))
                {
                    numbers[indexOfPaintingNumber] = changedNumber;
                }
            }
            else if (command == "Hide")
            {
                int paintingNumber = int.Parse(tokens[1]);

                if (numbers.Contains(paintingNumber))
                {
                    numbers.Remove(paintingNumber);
                }
            }
            else if (command == "Switch")
            {
                int firstPaintingNumber = int.Parse(tokens[1]);
                int secondPaintingNumber = int.Parse(tokens[2]);

                int indexOfFirst = numbers.IndexOf(firstPaintingNumber);
                int indexOfSecond = numbers.IndexOf(secondPaintingNumber);

                if (numbers.Contains(firstPaintingNumber) &&
                    numbers.Contains(secondPaintingNumber))
                {
                    int temp = firstPaintingNumber;
                    numbers[indexOfFirst] = secondPaintingNumber;
                    numbers[indexOfSecond] = temp;
                }
            }
            else if (command == "Insert")
            {
                int place = int.Parse(tokens[1]);
                int paintingNumber = int.Parse(tokens[2]);

                if (place >= 0 && place < numbers.Count)
                {
                    numbers.Insert(place + 1, paintingNumber);
                }
            }
            else if (command == "Reverse")
            {
                numbers.Reverse();
            }
        }
    }
}
