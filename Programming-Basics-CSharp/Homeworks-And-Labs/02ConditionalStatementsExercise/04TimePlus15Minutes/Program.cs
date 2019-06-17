using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int fromHoursToMinutes = hours * 60;
            int totalMinutes = fromHoursToMinutes + minutes + 15;

            TimeSpan result = TimeSpan.FromMinutes(totalMinutes);

            Console.WriteLine($"{result:h\\:mm}");

        }
    }
}
