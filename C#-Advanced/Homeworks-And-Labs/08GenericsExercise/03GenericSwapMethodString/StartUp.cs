namespace _03GenericSwapMethodString
{
    using System;
    using System.Linq;

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

            var swapCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
