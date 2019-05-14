using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int number = 0;
            int numberSum = 0;
            int biggestNumber = int.MinValue;
            int diff = 0;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                numberSum = numberSum + number;
                if (number > biggestNumber)
                {
                    biggestNumber = number;
                }
            }

            numberSum = numberSum - biggestNumber;

            diff = Math.Abs(biggestNumber - numberSum);

            if (biggestNumber == numberSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {numberSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
