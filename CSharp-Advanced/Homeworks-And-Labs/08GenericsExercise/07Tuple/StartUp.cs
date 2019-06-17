namespace _07Tuple
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var personData = Console.ReadLine()
                .Split()
                .ToArray();

            string personName = $"{personData[0]} {personData[1]}";
            string personAddress = personData[2];

            var personInfo = new Tuple<string, string>(personName, personAddress);

            Console.WriteLine(personInfo);

            var drunkPersonData = Console.ReadLine()
                .Split()
                .ToArray();

            string drunkPersonName = drunkPersonData[0];
            int drunkPersonLiterOfBeer = int.Parse(drunkPersonData[1]);

            var drunkPersonInfo = new Tuple<string, int>(drunkPersonName, drunkPersonLiterOfBeer);

            Console.WriteLine(drunkPersonInfo);

            var input = Console.ReadLine()
                .Split()
                .ToArray();

            int firstNumber = int.Parse(input[0]);
            double secondNumber = double.Parse(input[1]);

            var tuple = new Tuple<int, double>(firstNumber, secondNumber);

            Console.WriteLine(tuple);
        }
    }
}
