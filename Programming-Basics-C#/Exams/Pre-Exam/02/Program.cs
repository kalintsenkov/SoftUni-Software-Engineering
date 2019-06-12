using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());

            double shipVolume = width * length * height;
            double roomVolume = (averageHeight + 0.40) * 2 * 2;
            double spaceForAstronauts = Math.Floor(shipVolume / roomVolume);

            if(spaceForAstronauts>= 3 && spaceForAstronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {spaceForAstronauts} astronauts.");
            }
            else if(spaceForAstronauts < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else if(spaceForAstronauts > 10)
            {
                Console.WriteLine($"The spacecraft is too big.");
            }
        }
    }
}
