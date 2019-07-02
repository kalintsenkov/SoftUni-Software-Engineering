namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private long gold;
        private long gems;
        private long coins;

        public void Run()
        {
            var bag = new Dictionary<string, Dictionary<string, long>>();

            var bagCapacity = long.Parse(Console.ReadLine());

            var items = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < items.Length; i += 2)
            {
                var name = items[i];
                var amount = long.Parse(items[i + 1]);

                var itemName = TakeItemName(name);

                try
                {
                    CheckItem(bag, bagCapacity, amount, itemName);
                    CheckBag(bag, amount, itemName);
                }
                catch
                {
                    continue;
                }

                AddCurrentItem(bag, name, amount, itemName);

                IncreaseAmount(amount, itemName);
            }

            PrintResult(bag);
        }

        private void CheckBag(Dictionary<string, Dictionary<string, long>> bag, long amount, string itemName)
        {
            if (itemName == "Gem")
            {
                if (!bag.ContainsKey(itemName))
                {
                    if (bag.ContainsKey("Gold"))
                    {
                        if (amount > bag["Gold"].Values.Sum())
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                else if (bag[itemName].Values.Sum() + amount > bag["Gold"].Values.Sum())
                {
                    throw new InvalidOperationException();
                }
            }
            else if (itemName == "Cash")
            {
                if (!bag.ContainsKey(itemName))
                {
                    if (bag.ContainsKey("Gem"))
                    {
                        if (amount > bag["Gem"].Values.Sum())
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                else if (bag[itemName].Values.Sum() + amount > bag["Gem"].Values.Sum())
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void AddCurrentItem(Dictionary<string, Dictionary<string, long>> bag, string name, long amount, string itemName)
        {
            if (!bag.ContainsKey(itemName))
            {
                bag[itemName] = new Dictionary<string, long>();
            }

            if (!bag[itemName].ContainsKey(name))
            {
                bag[itemName][name] = 0;
            }

            bag[itemName][name] += amount;
        }

        private void IncreaseAmount(long amount, string itemName)
        {
            if (itemName == "Gold")
            {
                gold += amount;
            }
            else if (itemName == "Gem")
            {
                gems += amount;
            }
            else if (itemName == "Cash")
            {
                coins += amount;
            }
        }

        private void CheckItem(
            Dictionary<string, Dictionary<string, long>> bag,
            long bagCapacity,
            long amount,
            string itemName)
        {
            if (itemName == "" || bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
            {
                throw new InvalidOperationException();
            }
        }

        private string TakeItemName(string name)
        {
            string itemName = string.Empty;

            if (name.Length == 3)
            {
                itemName = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                itemName = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                itemName = "Gold";
            }

            return itemName;
        }

        private void PrintResult(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var type in bag)
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");

                foreach (var item in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
