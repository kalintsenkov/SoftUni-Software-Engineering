namespace Ferrari
{
    using System;
    using Contracts;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            var driverName = Console.ReadLine();

            ICar car = new Ferrari(driverName);

            Console.WriteLine(car);
        }
    }
}
