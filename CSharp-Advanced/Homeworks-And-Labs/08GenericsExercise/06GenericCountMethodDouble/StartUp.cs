namespace _06GenericCountMethodDouble
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                box.Add(number);
            }

            double value = double.Parse(Console.ReadLine());

            int greaterElements = box.GetGreaterElementsCount(value);

            Console.WriteLine(greaterElements);
        }
    }
}
