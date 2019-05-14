using System;
using System.Linq;

namespace _03EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopsList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Include")
                {
                    string shop = tokens[1];

                    shopsList.Add(shop);
                }
                else if (command == "Visit")
                {
                    string input = tokens[1];
                    int numberOfShops = int.Parse(tokens[2]);

                    if (input == "first" && numberOfShops <= shopsList.Count)
                    {
                        for (int index = 0; index < numberOfShops; index++)
                        {
                            shopsList.RemoveAt(0);
                        }
                    }
                    else if (input == "last" && numberOfShops <= shopsList.Count)
                    {
                        for (int index = 0; index < numberOfShops; index++)
                        {
                            shopsList.RemoveAt(shopsList.Count - 1);
                        }
                    }
                }
                else if (command == "Prefer")
                {
                    int firstShopIndex = int.Parse(tokens[1]);
                    int secondShopIndex = int.Parse(tokens[2]);

                    if ((firstShopIndex >= 0 && firstShopIndex < shopsList.Count) &&
                        (secondShopIndex >= 0 && secondShopIndex < shopsList.Count))
                    {
                        string temp = shopsList[firstShopIndex];
                        shopsList[firstShopIndex] = shopsList[secondShopIndex];
                        shopsList[secondShopIndex] = temp;
                    }
                }
                else if (command == "Place")
                {
                    string shop = tokens[1];
                    int shopIndex = int.Parse(tokens[2]);

                    if (shopIndex >= -1 && shopIndex < shopsList.Count - 1)
                    {
                        int resultedIndex = shopIndex + 1;

                        if (resultedIndex >= 0 && resultedIndex < shopsList.Count)
                        {
                            shopsList.Insert(resultedIndex, shop);
                        }
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopsList));
        }
    }
}
