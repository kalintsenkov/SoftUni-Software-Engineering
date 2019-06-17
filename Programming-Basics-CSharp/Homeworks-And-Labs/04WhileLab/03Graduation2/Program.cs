using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Graduation2
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
                    sumGrades += grade;
                    classCounter++;
                }
                else
                {
                    classCounter++;
                    break;
                }
            }
            double average = sumGrades / 12;

            if (classCounter > 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {--classCounter} grade");
            }
        }
    }
}
