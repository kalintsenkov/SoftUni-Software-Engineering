using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x1; i++)
            {
                for (int j = 1; j <= x2; j++)
                {
                    for (int k = 1; k <= x3; k++)
                    {
                        if((i % 2 == 0 && k % 2 == 0) && (j == 2 || j == 3 || j == 5 || j == 7))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
