using System;

namespace _10MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());

            int times = 1;
            int product = 0;

            for (int i = 1; i <= 10; i++)
            {
                product = integer * times;
                Console.WriteLine($"{integer} X {times} = {product}");
                times++;
            }
        }
    }
}
