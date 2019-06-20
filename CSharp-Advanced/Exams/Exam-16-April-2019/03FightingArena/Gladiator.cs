namespace FightingArena
{
    using System.Text;

    public class Gladiator
    {
        public string Name { get; private set; }

        public Stat Stat { get; private set; }

        public Weapon Weapon { get; private set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public int GetTotalPower()
        {
            int statPropSum = this.Stat.Strength + this.Stat.Skills 
                + this.Stat.Agility + this.Stat.Intelligence + this.Stat.Flexibility;

            int weaponPropSum = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;

            return statPropSum + weaponPropSum;
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return this.Stat.Strength + this.Stat.Skills
                + this.Stat.Agility + this.Stat.Intelligence + this.Stat.Flexibility;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            result.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            result.Append($"  Stat Power: [{this.GetStatPower()}]");

            return result.ToString();
        }
    }
}
