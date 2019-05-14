using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();

            if(age < 16)
            {
                if(sex == "m")
                {
                    Console.WriteLine("Master");
                }
                else if(sex == "f")
                {
                    Console.WriteLine("Miss");
                }
            }
            else
            {
                if (sex == "m")
                {
                    Console.WriteLine("Mr.");
                }
                else if(sex == "f")
                {
                    Console.WriteLine("Ms.");
                }
            }

        }
    }
}
