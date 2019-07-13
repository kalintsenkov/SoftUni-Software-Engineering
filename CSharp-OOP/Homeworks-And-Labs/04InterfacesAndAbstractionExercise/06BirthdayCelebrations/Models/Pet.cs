namespace BirthdayCelebrations.Models
{
    using Contracts;

    public class Pet : Mammal
    {
        public Pet(string name, string birthdate)
            : base(name, birthdate)
        {
        }
    }
}
