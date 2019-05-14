using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int firstDigit = number / 100;
            int secondDigit = (number / 10) % 10;
            int lastDigit = number % 10;

            int total = 0;

            for (int i = 1; i <= lastDigit; i++)
            {
                for (int j = 1; j <= secondDigit; j++)
                {
                    for (int k = 1; k <= firstDigit; k++)
                    {
                        total = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {total};");
                    }
                }
            }
        }
    }
}
