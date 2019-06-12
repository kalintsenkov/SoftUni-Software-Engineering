using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Histogram
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
            double p4Counter = 0;
            double p5Counter = 0;
            
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i < n; i++)
            {
                number = double.Parse(Console.ReadLine());
                if (number < 200)
                {
                    p1Counter++;
                    p1 = p1Counter / n * 100;
                }
                if (number >= 200 && number <= 399)
                {
                    p2Counter++;
                    p2 = p2Counter / n * 100;
                }
                if (number >= 400 && number <= 599)
                {
                    p3Counter++;
                    p3 = p3Counter / n * 100;
                }
                if (number >= 600 && number <= 799)
                {
                    p4Counter++;
                    p4 = p4Counter / n * 100;
                }
                if (number >= 800)
                {
                    p5Counter++;
                    p5 = p5Counter / n * 100;
                }
            }
            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
