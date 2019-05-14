using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int total = 0;
            int counter = 0;

            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n; x2++)
                {
                    for (int x3 = 0; x3 <= n; x3++)
                    {
                        for (int x4 = 0; x4 <= n; x4++)
                        {
                            for (int x5 = 0; x5 <= n; x5++)
                            {
                                total = x1 + x2 + x3 + x4 + x5;
                                if(total == n)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
