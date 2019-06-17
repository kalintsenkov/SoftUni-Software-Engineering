namespace DefiningClasses
{
    using System;

    public class Pokemon
    {
        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
    }
}
