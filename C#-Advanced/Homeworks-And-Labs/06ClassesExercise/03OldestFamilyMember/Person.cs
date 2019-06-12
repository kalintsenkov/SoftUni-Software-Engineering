namespace DefiningClasses
{
    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public Person()
        {
            this.Age = 1;
            this.Name = "No name";
        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
