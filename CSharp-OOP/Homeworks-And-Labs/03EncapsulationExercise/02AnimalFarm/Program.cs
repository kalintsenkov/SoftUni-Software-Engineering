namespace AnimalFarm
{
    using System;
    using Models;

    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            try
            {
                var chicken = new Chicken(name, age);

                Console.WriteLine(chicken);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
