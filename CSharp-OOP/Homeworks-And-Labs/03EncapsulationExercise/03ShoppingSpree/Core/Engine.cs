namespace ShoppingSpree.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                this.ReadPeopleInfo();
                this.ReadProductsInfo();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            while (true)
            {
                try
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var inputParts = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var personName = inputParts[0];
                    var productName = inputParts[1];

                    var person = this.people.FirstOrDefault(x => x.Name == personName);
                    var product = this.products.FirstOrDefault(x => x.Name == productName);

                    Console.WriteLine(person.AddProductsToBag(product));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void ReadProductsInfo()
        {
            var productsInput = Console.ReadLine();

            if (productsInput.Contains(";"))
            {
                var inputParts = productsInput
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                foreach (var part in inputParts)
                {
                    var parts = part
                        .Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var productName = parts[0];
                    var productCost = decimal.Parse(parts[1]);

                    var product = new Product(productName, productCost);

                    this.products.Add(product);
                }
            }
            else
            {
                var inputParts = productsInput
                .Split("=", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                var productName = inputParts[0];
                var productCost = decimal.Parse(inputParts[1]);

                var product = new Product(productName, productCost);

                this.products.Add(product);
            }
        }

        private void ReadPeopleInfo()
        {
            var peopleInput = Console.ReadLine();

            if (peopleInput.Contains(";"))
            {
                var inputParts = peopleInput
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var part in inputParts)
                {
                    var parts = part
                        .Split("=", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var personName = parts[0];
                    var personMoney = decimal.Parse(parts[1]);

                    var person = new Person(personName, personMoney);

                    this.people.Add(person);
                }
            }
            else
            {
                var inputParts = peopleInput
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var personName = inputParts[0];
                var personMoney = decimal.Parse(inputParts[1]);

                var person = new Person(personName, personMoney);

                this.people.Add(person);
            }
        }
    }
}
