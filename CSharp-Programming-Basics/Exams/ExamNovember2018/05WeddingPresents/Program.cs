using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05WeddingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            double guests = double.Parse(Console.ReadLine());
            double numberPresents = double.Parse(Console.ReadLine());

            double ACount = 0;
            double BCount = 0;
            double VCount = 0;
            double GCount = 0;

            double percentA = 0;
            double percentB = 0;
            double percentV = 0;
            double percentG = 0;
            double percentGuests = 0;

            for (int i = 0; i < numberPresents; i++)
            {
                string category = Console.ReadLine();
                if (category == "A")
                {
                    ACount++;
                    percentA = ACount / numberPresents * 100;
                }
                else if (category == "B")
                {
                    BCount++;
                    percentB = BCount / numberPresents * 100;
                }
                else if (category == "V")
                {
                    VCount++;
                    percentV = VCount / numberPresents * 100;
                }
                else if (category == "G")
                {
                    GCount++;
                    percentG = GCount / numberPresents * 100;
                }
                percentGuests = numberPresents / guests * 100;
            }
            Console.WriteLine($"{percentA:F2}%");
            Console.WriteLine($"{percentB:F2}%");
            Console.WriteLine($"{percentV:F2}%");
            Console.WriteLine($"{percentG:F2}%");
            Console.WriteLine($"{percentGuests:F2}%");
        }
    }
}
