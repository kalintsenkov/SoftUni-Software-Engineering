using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double classCounter = 1;
            double sumGrades = 0;

            while (classCounter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sumGrades = sumGrades + grade;
                    classCounter++;
                }
            }
            double average = sumGrades / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
        }
    }
}
