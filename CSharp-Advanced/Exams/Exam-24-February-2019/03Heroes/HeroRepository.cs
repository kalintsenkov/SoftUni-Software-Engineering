namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> heroes;

        public int Count { get => this.heroes.Count; }

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            if (!this.heroes.Any(x => x.Name == hero.Name))
            {
                this.heroes.Add(hero);
            }
        }

        public void Remove(string name)
        {
            if (this.heroes.Any(x => x.Name == name))
            {
                this.heroes.RemoveAll(x => x.Name == name);
            }
        }

        public Hero GetHeroWithHighestStrength() 
            => this.heroes
            .OrderByDescending(x => x.Item.Strength)
            .FirstOrDefault();

        public Hero GetHeroWithHighestAbility()
            => this.heroes
            .OrderByDescending(x => x.Item.Ability)
            .FirstOrDefault();

        public Hero GetHeroWithHighestIntelligence()
            => this.heroes
            .OrderByDescending(x => x.Item.Intelligence)
            .FirstOrDefault();

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var hero in this.heroes)
            {
                result.AppendLine($"{hero}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
