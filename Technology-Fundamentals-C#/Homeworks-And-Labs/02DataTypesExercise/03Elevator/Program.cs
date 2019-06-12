using System;

namespace _03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int capacityOfPersons = int.Parse(Console.ReadLine());

            double fullCourses = (double)persons / capacityOfPersons;
            Console.WriteLine(Math.Ceiling(fullCourses));
        }
    }
}
