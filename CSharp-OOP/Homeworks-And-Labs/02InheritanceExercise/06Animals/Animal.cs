namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; private set; }

        public int Age
        {
            get => this.age;

            protected set
            {
                if (value < 1)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender { get; private set; }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.AppendLine(this.ProduceSound());

            return result.ToString().TrimEnd();
        }
    }
}
