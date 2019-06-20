namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public string Name { get; private set; }

        public int Count { get => this.gladiators.Count; }

        public Arena(string name)
        {
            this.Name = name;
            gladiators = new List<Gladiator>();
        }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiator = this.gladiators.FirstOrDefault(x => x.Name == name);

            this.gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
            => this.gladiators
            .OrderByDescending(x => x.GetStatPower())
            .FirstOrDefault();

        public Gladiator GetGladitorWithHighestWeaponPower()
            => this.gladiators
            .OrderByDescending(x => x.GetWeaponPower())
            .FirstOrDefault();

        public Gladiator GetGladitorWithHighestTotalPower()
            => this.gladiators
            .OrderByDescending(x => x.GetTotalPower())
            .FirstOrDefault();

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
