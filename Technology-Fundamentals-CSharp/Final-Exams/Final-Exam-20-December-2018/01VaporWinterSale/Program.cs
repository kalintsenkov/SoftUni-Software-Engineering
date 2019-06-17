using System;
using System.Collections.Generic;
using System.Linq;

namespace _01VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamesList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var gamesWithDLC = new Dictionary<string, decimal>();
            var gamesWithOutDLC = new Dictionary<string, decimal>();

            for (int i = 0; i < gamesList.Count; i++)
            {
                string currentGame = gamesList[i];

                if (currentGame.Contains("-"))
                {
                    var tokens = currentGame
                        .Split("-", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string gameName = tokens[0];
                    decimal price = decimal.Parse(tokens[1]);

                    if (!gamesWithOutDLC.ContainsKey(gameName))
                    {
                        gamesWithOutDLC.Add(gameName, price);
                    }
                }
                else if (currentGame.Contains(":"))
                {
                    var tokens = currentGame
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string gameName = tokens[0];
                    string DLC = tokens[1];

                    if (gamesWithOutDLC.ContainsKey(gameName))
                    {
                        decimal price = gamesWithOutDLC[gameName] + gamesWithOutDLC[gameName] * 0.2m;

                        if (!gamesWithDLC.ContainsKey(gameName))
                        {
                            gamesWithDLC.Add($"{gameName} - {DLC}", price);
                        }

                        gamesWithOutDLC.Remove(gameName);
                    }
                }
            }

            foreach (var game in gamesWithDLC.OrderBy(x => x.Value))
            {
                decimal price = game.Value - game.Value * 0.5m;
                Console.WriteLine($"{game.Key} - {price:F2}");
            }

            foreach (var game in gamesWithOutDLC.OrderByDescending(x => x.Value))
            {
                decimal price = game.Value - game.Value * 0.2m;
                Console.WriteLine($"{game.Key} - {price:F2}");
            }
        }
    }
}
