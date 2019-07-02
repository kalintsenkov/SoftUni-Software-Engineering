namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var randomList = new RandomList
            {
                "Ivan",
                "Pesho",
                "Gosho"
            };

            Console.WriteLine(randomList.RandomString());
        }
    }
}
