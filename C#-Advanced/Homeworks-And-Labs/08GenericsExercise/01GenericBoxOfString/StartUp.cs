namespace _01GenericBoxOfString
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

            Console.WriteLine(box);
        }
    }
}
