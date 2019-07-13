namespace Animals
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            IAnimal cat = new Cat("Pesho", "Whiskas");
            IAnimal dog = new Dog("Gosho", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
