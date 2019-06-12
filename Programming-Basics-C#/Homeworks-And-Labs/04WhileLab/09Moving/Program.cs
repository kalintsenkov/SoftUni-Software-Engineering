using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthRoom = int.Parse(Console.ReadLine());
            int lengthRoom = int.Parse(Console.ReadLine());
            int heightRoom = int.Parse(Console.ReadLine());

            int roomArea = widthRoom * lengthRoom * heightRoom;
            int boxes = 0;
            int currentCapacity = 0;
            int metersNeeded = 0;
            int metersFree = 0;

            string command = Console.ReadLine();

            while (command != "Done")
            {
                boxes = int.Parse(command);
                currentCapacity += boxes;
                if (roomArea < currentCapacity)
                {
                    metersNeeded = Math.Abs(roomArea - currentCapacity);
                    Console.WriteLine($"No more free space! You need {metersNeeded} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();
            }

            if (command == "Done")
            {
                metersFree = roomArea - currentCapacity;
                Console.WriteLine($"{metersFree} Cubic meters left.");
            }
        }
    }
}
