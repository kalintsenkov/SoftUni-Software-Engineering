namespace BirthdayCelebrations.Models
{
    using Contracts;

    public abstract class Mammal : IMammal
    {
        protected Mammal(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; }

        public string Birthdate { get; }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }
    }
}
