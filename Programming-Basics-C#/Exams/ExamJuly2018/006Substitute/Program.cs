using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int a = K; a <= 8; a++)
            {
                for (int b = 9; b >= L; b--)
                {
                    for (int c = M; c <= 8; c++)
                    {
                        for (int d = 9; d >= N; d--)
                        {
                            if ((a % 2 == 0 && c % 2 == 0) && (b % 2 != 0 && d % 2 != 0))
                            {
                                if (a == c && b == d)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{a}{b} - {c}{d}");
                                    counter++;
                                }

                                if (counter == 6)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
