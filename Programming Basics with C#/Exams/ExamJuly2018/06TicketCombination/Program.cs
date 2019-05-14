using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            int sum = 0;

            for (char stadiumName = 'B'; stadiumName <= 'L'; stadiumName++)
            {
                for (char sectorName = 'f'; sectorName >= 'a'; sectorName--)
                {
                    for (char entrance = 'A'; entrance <= 'C'; entrance++)
                    {
                        for (int row = 1; row <= 10; row++)
                        {
                            for (int seat = 10; seat >= 1; seat--)
                            {
                                if(stadiumName % 2 == 0)
                                {
                                    counter++;
                                }
                                if(counter == n)
                                {
                                    sum = stadiumName + sectorName + entrance + row + seat;
                                    Console.WriteLine($"Ticket combination: {stadiumName}{sectorName}{entrance}{row}{seat}");
                                    Console.WriteLine($"Prize: {sum} lv.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
