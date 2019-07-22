namespace ValidationAttributes.Entities
{
    using Attributes;

    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; private set; }
    }
}
