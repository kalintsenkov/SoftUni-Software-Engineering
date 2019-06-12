using System;
using System.Linq;
using System.Collections.Generic;

namespace _04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            var quantityOfOrders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>(quantityOfOrders);

            int biggestOrder = queue.Max();

            while (queue.Any())
            {
                int currentOrder = queue.Peek();

                if (foodQuantity - currentOrder >= 0)
                {
                    foodQuantity -= currentOrder;
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
