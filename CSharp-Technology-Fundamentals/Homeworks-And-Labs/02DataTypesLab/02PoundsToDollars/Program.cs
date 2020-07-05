using System;

namespace _02PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());

            decimal poundsToDollar = pounds * 1.31m;
            Console.WriteLine($"{poundsToDollar:f3}");
        }
    }
}
