using System;
using System.Linq;
using System.Collections.Generic;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < firstDeck.Count; i++)
            {
                for (int j = i; j < secondDeck.Count; j++)
                {
                    if (firstDeck[i] > secondDeck[j])
                    {
                        firstDeck.Add(firstDeck[i]); // add winning card to winners deck
                        firstDeck.RemoveAt(i);
                        firstDeck.Add(secondDeck[j]); // add losing card to winners deck

                        secondDeck.RemoveAt(j); // loser removes his card
                    }
                    else if (secondDeck[j] > firstDeck[i])
                    {
                        secondDeck.Add(secondDeck[j]);
                        secondDeck.RemoveAt(j);
                        secondDeck.Add(firstDeck[i]);

                        firstDeck.RemoveAt(j);
                    }
                    else if (firstDeck[i] == secondDeck[j])
                    {
                        firstDeck.RemoveAt(i);
                        secondDeck.RemoveAt(j);
                    }

                    if (firstDeck.Count == 0)
                    {
                        Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
                        return;
                    }
                    else if(secondDeck.Count == 0)
                    {
                        Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
                        return;
                    }

                    i = 0;
                    j = -1;
                }
            }
        }
    }
}
