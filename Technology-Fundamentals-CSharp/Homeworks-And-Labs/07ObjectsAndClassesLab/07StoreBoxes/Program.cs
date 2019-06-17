using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StoreBoxes
{
    public class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public int SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var boxesList = new List<Box>();

            while (input != "end")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int serialNumber = int.Parse(tokens[0]);
                string itemName = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);

                decimal boxPrice = (decimal)quantity * itemPrice;

                boxesList.Add(new Box
                {
                    SerialNumber = serialNumber,
                    Quantity = quantity,
                    Price = boxPrice,
                    Item = new Item
                    {
                        Name = itemName,
                        Price = itemPrice
                    }
                });

                input = Console.ReadLine();
            }

            foreach (var box in boxesList.OrderByDescending(x => x.Price))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }
}
