namespace ValidationAttributes
{
    using System;

    using Entities;

    public class StartUp
    {
        public static void Main()
        {
            var person = new Person(null, -1);

            var isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
