namespace GenericScale
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var scale = new EqualityScale<string>("5", "5");
            Console.WriteLine(scale.AreEqual());
        }
    }
}
