namespace _05GenericCountMethodString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
            }

            string value = Console.ReadLine();

            int greaterElements = box.GetGreaterElementsCount(value);

            Console.WriteLine(greaterElements);
        }
    }
}
