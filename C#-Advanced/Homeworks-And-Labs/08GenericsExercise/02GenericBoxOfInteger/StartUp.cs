namespace _02GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                box.Add(number);
            }

            Console.WriteLine(box);
        }
    }
}
