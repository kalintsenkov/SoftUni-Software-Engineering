namespace Heroes
{
    using System;
    using System.Text;

    public class Item
    {
        public int Strength { get; private set; }

        public int Ability { get; private set; }

        public int Intelligence { get; private set; }

        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Item:");
            result.AppendLine($"  * Strength: {this.Strength}");
            result.AppendLine($"  * Ability: {this.Ability}");
            result.Append($"  * Intelligence: {this.Intelligence}");

            return result.ToString();
        }
    }
}
