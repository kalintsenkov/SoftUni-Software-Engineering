using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()) / 100;

            double volume = length * width * height;

            double volumeInLiters = volume / 1000;

            double litersNeeded = volumeInLiters - (volumeInLiters * percentage);

            Console.WriteLine($"{litersNeeded:F3}");
        }
    }
}
