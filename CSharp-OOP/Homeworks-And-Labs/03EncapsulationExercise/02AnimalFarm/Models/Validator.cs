namespace AnimalFarm.Models
{
    using System;

    public class Validator
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;
        private const string NameCannotBeEmptyException = "Name cannot be empty.";

        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(NameCannotBeEmptyException);
            }
        }

        public static void ValidateAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
            }
        }
    }
}
