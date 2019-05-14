using System;
using System.Linq;

namespace _02EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var giftsList = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToList();

            string input = Console.ReadLine();

            while (input != "No Money")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "OutOfStock")
                {
                    string gift = tokens[1];

                    if (giftsList.Contains(gift))
                    {
                        for (int i = 0; i < giftsList.Count; i++)
                        {
                            if (giftsList[i] == gift)
                            {
                                giftsList[i] = "None";
                            }
                        }
                    }
                }
                else if (command == "Required")
                {
                    string gift = tokens[1];
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < giftsList.Count)
                    {
                        giftsList[index] = gift;
                    }
                }
                else if (command == "JustInCase")
                {
                    string gift = tokens[1];
                    int lastGiftIndex = giftsList.Count - 1;

                    giftsList[lastGiftIndex] = gift;
                }

                input = Console.ReadLine();
            }

            giftsList.RemoveAll(x => x == "None");

            Console.WriteLine(string.Join(" ", giftsList));
        }
    }
}
