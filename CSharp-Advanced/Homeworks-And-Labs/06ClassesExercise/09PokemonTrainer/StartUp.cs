using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                var trainerInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = trainerInfo[0];
                string pokemonName = trainerInfo[1];
                string pokemonElement = trainerInfo[2];
                int pokemonHealth = int.Parse(trainerInfo[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].AddPokemons(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Fire")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        trainer.CheckPokemons(input);
                    }
                }
                else if (input == "Water")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        trainer.CheckPokemons(input);
                    }
                }
                else if (input == "Electricity")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        trainer.CheckPokemons(input);
                    }
                }

                input = Console.ReadLine();
            }

            var result = trainers.Values
                .OrderByDescending(x => x.Badges)
                .ToList();

            foreach (var trainer in result)
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
