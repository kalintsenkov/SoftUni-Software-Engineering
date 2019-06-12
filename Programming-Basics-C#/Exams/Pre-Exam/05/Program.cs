using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPassengers = int.Parse(Console.ReadLine());
            int numberStops = int.Parse(Console.ReadLine());

            int passengersGetOut = 0;
            int passengersLift = 0;

            int totalPassengers = 0;

            for (int stops = 1; stops <= numberStops; stops++)
            {
                passengersGetOut = int.Parse(Console.ReadLine());
                passengersLift = int.Parse(Console.ReadLine());
                if (stops % 2 != 0)
                {
                    totalPassengers = numberPassengers - passengersGetOut + passengersLift + 2;
                }
                else if (stops % 2 == 0)
                {
                    totalPassengers = totalPassengers - passengersGetOut + passengersLift - 2 ;
                    numberPassengers = totalPassengers;
                }
            }
            Console.WriteLine($"The final number of passengers is : {totalPassengers}");
        }
    }
}
