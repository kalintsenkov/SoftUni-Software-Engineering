using System;

namespace _01ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meter = int.Parse(Console.ReadLine());

            decimal kilometer = meter / 1000m;
            Console.WriteLine($"{kilometer:f2}");
        }
    }
}
