using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPoorMarks = int.Parse(Console.ReadLine());

            int poorMarkCount = 0;
            double average = 0;
            double numberProblems = 0;
            double markSum = 0;
            string lastProblem = " ";

            string problemName = Console.ReadLine();

            while (problemName != "Enough")
            {
                int mark = int.Parse(Console.ReadLine());
                markSum = markSum + mark;
                numberProblems++;
                lastProblem = problemName;
                if (mark <= 4)
                {
                    poorMarkCount++;
                }
                if (poorMarkCount == numberPoorMarks)
                {
                    Console.WriteLine($"You need a break, {poorMarkCount} poor grades.");
                    break;
                }
                problemName = Console.ReadLine();
            }

            if (problemName == "Enough")
            {
                average = markSum / numberProblems;
                Console.WriteLine($"Average score: {average:F2}");
                Console.WriteLine($"Number of problems: {numberProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
