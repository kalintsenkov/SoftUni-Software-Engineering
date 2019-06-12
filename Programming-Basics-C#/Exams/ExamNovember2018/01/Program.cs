using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double sideBar = double.Parse(Console.ReadLine());

            double sizeHall = length * width;
            double sizeBar = sideBar * sideBar;
            double sizeDancing = sizeHall * 0.19;
            double freeSpace = sizeHall - sizeBar - sizeDancing;
            double numberGuests = freeSpace / 3.2;
            Console.WriteLine(Math.Ceiling(numberGuests));
        }
    }
}
