using System;

namespace _09SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;

            for (int i = 1; i <= 100; i=i+2)
            {
                Console.WriteLine(i);
                counter++;
                sum = sum + i;
                if(counter == n)
                {
                    break;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
