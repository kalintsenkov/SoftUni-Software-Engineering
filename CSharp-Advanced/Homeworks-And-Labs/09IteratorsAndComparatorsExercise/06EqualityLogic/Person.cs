namespace IteratorsAndComparators
{
    using System;

    public class Person : IComparable<Person>
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                return this.Age - other.Age;
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Person)obj).Name && this.Age == ((Person)obj).Age;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode() + (257 * 53);
        }
    }
}
