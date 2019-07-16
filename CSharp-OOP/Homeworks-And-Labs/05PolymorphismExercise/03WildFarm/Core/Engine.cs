namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Exceptions;
    using Models.Animals.Birds;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;
    using Models.Foods;

    public class Engine
    {
        private readonly List<IAnimal> animals;

        public Engine()
        {
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var animalInfo = input.Split();
                var foodInfo = Console.ReadLine().Split();

                try
                {
                    var animal = this.CreateAnimal(animalInfo);
                    var food = this.CreateFood(foodInfo);

                    this.animals.Add(animal);

                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (InvalidFoodException ife)
                {
                    Console.WriteLine(ife.Message);
                }

                input = Console.ReadLine();
            }

            this.PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IFood CreateFood(string[] foodInfo)
        {
            var type = foodInfo[0];
            var quantity = int.Parse(foodInfo[1]);

            IFood food = null;

            if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }

        private IAnimal CreateAnimal(string[] animalInfo)
        {
            var type = animalInfo[0];
            var name = animalInfo[1];
            var weight = double.Parse(animalInfo[2]);

            IAnimal animal = null;

            if (type == "Owl")
            {
                var wingSize = double.Parse(animalInfo[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                var wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                var livingRegion = animalInfo[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                var livingRegion = animalInfo[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                var livingRegion = animalInfo[3];
                var breed = animalInfo[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                var livingRegion = animalInfo[3];
                var breed = animalInfo[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
