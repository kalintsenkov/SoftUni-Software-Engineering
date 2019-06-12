namespace _08Threeuple
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
            string personTown = personData[3];

            var personInfo = new Threeuple<string, string, string>(personName, personAddress, personTown);

            Console.WriteLine(personInfo);

            var drunkPersonData = Console.ReadLine()
                .Split()
                .ToArray();

            string drunkPersonName = drunkPersonData[0];
            int drunkPersonLiterOfBeer = int.Parse(drunkPersonData[1]);
            bool isDrunk = IsPersonDrunk(drunkPersonData[2]);

            var drunkPersonInfo = new Threeuple<string, int, bool>(drunkPersonName, drunkPersonLiterOfBeer, isDrunk);

            Console.WriteLine(drunkPersonInfo);

            var accountBalanceData = Console.ReadLine()
                .Split()
                .ToArray();

            string username = accountBalanceData[0];
            double accountBalance = double.Parse(accountBalanceData[1]);
            string bankName = accountBalanceData[2];

            var accountBalanceInfo = new Threeuple<string, double, string>(username, accountBalance, bankName);

            Console.WriteLine(accountBalanceInfo);
        }

        public static bool IsPersonDrunk(string input)
        {
            if (input == "drunk")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
