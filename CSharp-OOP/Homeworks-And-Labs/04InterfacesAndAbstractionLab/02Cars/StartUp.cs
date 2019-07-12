namespace Cars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ICar seat = new Seat("Leon", "Gray");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
        }
    }
}
