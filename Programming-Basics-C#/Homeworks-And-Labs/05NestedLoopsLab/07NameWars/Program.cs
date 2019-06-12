using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07NameWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int sum = 0;
            int biggestSum = int.MinValue;
            string winnerName = "";

            while (name != "STOP")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    sum = sum + name[i];
                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        winnerName = name;
                    }
                }
                sum = 0;
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {winnerName} - {biggestSum}!");
        }   
    }
}
