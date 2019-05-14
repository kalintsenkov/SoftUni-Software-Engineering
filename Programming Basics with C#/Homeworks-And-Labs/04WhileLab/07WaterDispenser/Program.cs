using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07WaterDispenser
{
    class Program
    {
        static void Main(string[] args)
        {
            int glassVolume = int.Parse(Console.ReadLine());

            int totalSum = 0;
            int numberPushes = 0;

            while (glassVolume > totalSum)
            {
                string button = Console.ReadLine();

                if (button == "Easy")
                {
                    totalSum = totalSum + 50;
                }
                else if(button == "Medium")
                {
                    totalSum = totalSum + 100;
                }
                else if(button == "Hard")
                {
                    totalSum = totalSum + 200;
                }
                numberPushes++;
            }
            if (glassVolume == totalSum)
            {
                Console.WriteLine($"The dispenser has been tapped {numberPushes} times.");
            }
            else if (totalSum > glassVolume)
            {
                Console.WriteLine($"{totalSum-glassVolume}ml has been spilled.");
            }
        }
    }
}
