using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double number = 0;

            double p1Counter = 0;
            double p2Counter = 0;
            double p3Counter = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    p1Counter++;
                    p1 = p1Counter / n * 100;
                }
                if (number % 3 == 0)
                {
                    p2Counter++;
                    p2 = p2Counter / n * 100;
                }
                if (number % 4 == 0)
                {
                    p3Counter++;
                    p3 = p3Counter / n * 100;
                }
            }
            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
