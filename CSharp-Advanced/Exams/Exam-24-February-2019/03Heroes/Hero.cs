namespace Heroes
{
    using System;
    using System.Text;

    public class Hero
    {
        public string Name { get; private set; }

        public int Level { get; private set; }

        public Item Item { get; private set; }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            result.Append($"{this.Item}");

            return result.ToString();
        }
    }
}
