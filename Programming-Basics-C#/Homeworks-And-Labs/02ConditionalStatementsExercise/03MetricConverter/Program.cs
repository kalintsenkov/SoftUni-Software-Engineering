using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberToConvert = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double result1 = 0;
            double result2 = 0;
            double m = 1;
            double mm = 1000;
            double cm = 100;
            double mi = 0.000621371192;
            double @in = 39.3700787;
            double km = 0.001;
            double ft = 3.2808399;
            double yd = 1.0936133;

            if (input == "m")
            {
                result1 = numberToConvert / m;
            }
            else if(input == "mm")
            {
                result1 = numberToConvert / mm;
            }
            else if(input == "cm")
            {
                result1 = numberToConvert / cm;
            }
            else if (input == "mi")
            {
                result1 = numberToConvert / mi;
            }
            else if (input == "in")
            {
                result1 = numberToConvert / @in;
            }
            else if (input == "km")
            {
                result1 = numberToConvert / km;
            }
            else if (input == "ft")
            {
                result1 = numberToConvert / ft;
            }
            else if (input == "yd")
            {
                result1 = numberToConvert / yd;
            }


            if (output == "m")
            {
                result2 = result1 * m;
            }
            else if(output == "mm")
            {
                result2 = result1 * mm;
            }
            else if (output == "cm")
            {
                result2 = result1 * cm;
            }
            else if (output == "mi")
            {
                result2 = result1 * mi;
            }
            else if (output == "in")
            {
                result2 = result1 * @in;
            }
            else if (output == "km")
            {
                result2 = result1 * km;
            }
            else if (output == "ft")
            {
                result2 = result1 * ft;
            }
            else if (output == "yd")
            {
                result2 = result1 * yd;
            }
            Console.WriteLine($"{result2:f8}");
        }
    }
}
