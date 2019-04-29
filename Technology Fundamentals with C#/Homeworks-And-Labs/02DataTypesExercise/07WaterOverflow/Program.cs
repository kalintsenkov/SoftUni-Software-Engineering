using System;

namespace _07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 0;

            for (int i = 1; i <= n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (capacity + liters > 255) // waterTankCapacity = 255;
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity = capacity + liters;
                }
            }
            Console.WriteLine(capacity);
        }
    }
}
