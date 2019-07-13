namespace FoodShortage.Models
{
    using Contracts;

    public abstract class Person : IBuyer
    {
        protected Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        protected Person(string name, int age, string birthdate)
            :this (name, age)
        {
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
