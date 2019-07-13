namespace FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Engine
    {
        private readonly List<IBuyer> buyers;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            var peopleCount = int.Parse(Console.ReadLine());

            this.AddPeople(peopleCount);

            var name = Console.ReadLine();

            while (name != "End")
            {
                var person = this.buyers.FirstOrDefault(x => x.Name == name);

                if (person != null)
                {
                    person.BuyFood();
                }

                name = Console.ReadLine();
            }

            var totalFoodAmount = this.buyers.Sum(x => x.Food);

            Console.WriteLine(totalFoodAmount);
        }

        private void AddPeople(int peopleCount)
        {
            for (int i = 0; i < peopleCount; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (personInfo.Length == 3)
                {
                    var rebel = this.CreateRebel(personInfo);
                    this.buyers.Add(rebel);
                }
                else if (personInfo.Length == 4)
                {
                    var citizen = this.CreateCitizen(personInfo);
                    this.buyers.Add(citizen);
                }
            }
        }

        private IBuyer CreateCitizen(string[] personInfo)
        {
            var citizenName = personInfo[0];
            var citizenAge = int.Parse(personInfo[1]);
            var citizenId = personInfo[2];
            var citizenBirthdate = personInfo[3];

            IBuyer citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
            return citizen;
        }

        private IBuyer CreateRebel(string[] personInfo)
        {
            var rebelName = personInfo[0];
            var rebelAge = int.Parse(personInfo[1]);
            var group = personInfo[2];

            IBuyer rebel = new Rebel(rebelName, rebelAge, group);
            return rebel;
        }
    }
}
