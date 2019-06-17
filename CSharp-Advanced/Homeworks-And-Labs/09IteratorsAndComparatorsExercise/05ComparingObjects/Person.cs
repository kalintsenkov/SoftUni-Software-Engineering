namespace IteratorsAndComparators
{
    using System;

    public class Person : IComparable<Person>
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age - other.Age != 0)
            {
                return this.Age - other.Age;
            }

            if (this.Town.CompareTo(other.Town) != 0)
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}
