using System;

namespace _01Bonus_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonusPoints = 0;
            int maxAttendances = 0;

            for (int i = 1; i <= studentsCount; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());

                double bonusPoints = Math.Ceiling((double)studentAttendances / lecturesCount * (5.00 + additionalBonus));

                if (bonusPoints >= maxBonusPoints)
                {
                    maxBonusPoints = bonusPoints;
                    maxAttendances = studentAttendances;
                }
            }

            Console.WriteLine($"The maximum bonus score for this course is {maxBonusPoints}.The student has attended {maxAttendances} lectures.");
        }
    }
}
