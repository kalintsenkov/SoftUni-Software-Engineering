using System;

namespace _08MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double poweringNumber = double.Parse(Console.ReadLine());

            double mathPower = PowerANumber(number, poweringNumber);

            Console.WriteLine(mathPower);
        }

        static double PowerANumber(double number, double power)
        {
            double result = 1;

            for (int i = 1; i <= power; i++)
            {
                result = result * number;
            }

            return result;
        }
    }
}
