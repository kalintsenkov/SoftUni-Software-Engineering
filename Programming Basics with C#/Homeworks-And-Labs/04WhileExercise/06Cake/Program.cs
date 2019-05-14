using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthCake = int.Parse(Console.ReadLine());
            int lengthCake = int.Parse(Console.ReadLine());

            int cakeArea = widthCake * lengthCake;
            int piecesSum = 0;
            int piecesLeft = 0;
            int piecesNeeded = 0;
            
            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int picesOfCake = int.Parse(command);
                piecesSum = piecesSum + picesOfCake;

                if (piecesSum > cakeArea)
                {
                    piecesNeeded = piecesSum - cakeArea;
                    Console.WriteLine($"No more cake left! You need {piecesNeeded} pieces more.");
                    break;
                }
                command = Console.ReadLine();
            }

            if (command == "STOP")
            {
                piecesLeft = cakeArea - piecesSum;
                Console.WriteLine($"{piecesLeft} pieces are left.");
            }
        }
    }
}
