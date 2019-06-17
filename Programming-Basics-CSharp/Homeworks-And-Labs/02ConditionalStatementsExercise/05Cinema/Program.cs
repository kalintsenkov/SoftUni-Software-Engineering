using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeShow = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double result = 0;
            if (typeShow == "Premiere")
            {
                result = r * c * 12;
            }
            else if(typeShow == "Normal")
            {
                result = r * c * 7.50;
            }
            else if(typeShow == "Discount")
            {
                result = r * c * 5;
            }
            Console.WriteLine($"{result:F2} leva");
        }
    }
}
