using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFloors = int.Parse(Console.ReadLine());
            int numberRooms = int.Parse(Console.ReadLine());

            for (int floor = numberFloors; floor >= 1; floor--)
            {
                for (int roomNumber = 0; roomNumber < numberRooms; roomNumber++)
                {
                    if(floor == numberFloors)
                    {
                        Console.Write($"L{floor}{roomNumber} ");
                        continue;
                    }
                    if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{roomNumber} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{roomNumber} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
