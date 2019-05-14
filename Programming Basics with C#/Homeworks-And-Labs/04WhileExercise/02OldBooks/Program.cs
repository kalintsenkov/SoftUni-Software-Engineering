using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int capacityLibrary = int.Parse(Console.ReadLine());
            int bookCounter = 0;

            while (capacityLibrary != bookCounter)
            {
                string input = Console.ReadLine();
                if (input == book)
                {
                    bookCounter++;
                    Console.WriteLine($"You checked {--bookCounter} books and found it.");
                    break;
                }
                bookCounter++;
                if (bookCounter == capacityLibrary)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCounter} books.");
                    break;
                }
            }
        }
    }
}
