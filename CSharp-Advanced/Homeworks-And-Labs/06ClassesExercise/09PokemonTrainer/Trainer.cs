namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;

    public class Trainer
    {
        private List<Pokemon> pokemons;

        public string Name { get; set; }

        public int Badges { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public void AddPokemons(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public void CheckPokemons(string element)
        {
            foreach (var pokemon in pokemons)
            {
                if (pokemon.Element == element)
                {
                    this.Badges++;
                    break;
                }
                else
                {
                    pokemon.Health -= 10;
                }
            }

            for (int i = 0; i < pokemons.Count; i++)
            {
                Pokemon pokemon = pokemons[i];

                if (pokemon.Health <= 0)
                {
                    pokemons.Remove(pokemon);
                    i--;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.pokemons.Count}";
        }
    }
}
