using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if(type == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double areaSquare = squareSide * squareSide;
                Console.WriteLine(Math.Round(areaSquare, 3));
            } 
            else if(type == "rectangle")
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double areaRectangle = length * width;
                Console.WriteLine(Math.Round(areaRectangle, 3));
            }
            else if(type == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double areaCircle = radius * radius * Math.PI;
                Console.WriteLine(Math.Round(areaCircle, 3));
            }
            else if(type == "triangle")
            {
                double sideTriangle = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double areaTriangle = (sideTriangle * h) / 2;
                Console.WriteLine(Math.Round(areaTriangle, 3));
            }

        }
    }
}
