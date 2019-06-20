namespace FightingArena
{
    public class Stat
    {
        public int Strength { get; private set; }

        public int Flexibility { get; private set; }

        public int Agility { get; private set; }

        public int Skills { get; private set; }

        public int Intelligence { get; private set; }

        public Stat(
            int strength, 
            int flexibility, 
            int agility, 
            int skills, 
            int intelligence)
        {
            this.Strength = strength;
            this.Flexibility = flexibility;
            this.Agility = agility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }
    }
}
