using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double number = 0;

            double evenSum = 0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;

            double oddSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;

            for (double i = 1; i <= n; i++)
            {
                number = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum = evenSum + number;
                    if (number > evenMax)
                    {
                        evenMax = number;
                    }
                    if(number < evenMin)
                    {
                        evenMin = number;
                    }
                }
                else
                {
                    oddSum = oddSum + number;
                    if (number > oddMax)
                    {
                        oddMax = number;
                    }
                    if (number < oddMin)
                    {
                        oddMin = number;
                    }
                }
            }

            if (n == 0)
            {
                Console.WriteLine($"OddSum={oddSum},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={evenSum},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else if (n == 1)
            {
                Console.WriteLine($"OddSum={oddSum},");
                Console.WriteLine($"OddMin={oddMin},");
                Console.WriteLine($"OddMax={oddMax},");
                Console.WriteLine($"EvenSum={evenSum},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"OddSum={oddSum},");
                Console.WriteLine($"OddMin={oddMin},");
                Console.WriteLine($"OddMax={oddMax},");
                Console.WriteLine($"EvenSum={evenSum},");
                Console.WriteLine($"EvenMin={evenMin},");
                Console.WriteLine($"EvenMax={evenMax}");
            }
        }
    }
}
