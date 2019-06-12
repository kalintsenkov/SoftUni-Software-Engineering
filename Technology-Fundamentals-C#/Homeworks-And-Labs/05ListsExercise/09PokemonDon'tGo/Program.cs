using System;
using System.Linq;
using System.Collections.Generic;

namespace _09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sumOfRemovedNumbers = 0;

            while (pokemons.Count != 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                
                if(indexToRemove >= 0 && indexToRemove < pokemons.Count)
                {
                    int removedNumber = pokemons[indexToRemove];
                    sumOfRemovedNumbers = sumOfRemovedNumbers + removedNumber;

                    pokemons.RemoveAt(indexToRemove);

                    IncreasingAndDecreasing(pokemons, removedNumber);
                }
                else if (indexToRemove < 0)
                {
                    int removedNumber = pokemons[0];
                    sumOfRemovedNumbers = sumOfRemovedNumbers + removedNumber;

                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);

                    IncreasingAndDecreasing(pokemons, removedNumber);
                }
                else if (indexToRemove > pokemons.Count - 1)
                {
                    int removedNumber = pokemons[pokemons.Count - 1];
                    sumOfRemovedNumbers = sumOfRemovedNumbers + removedNumber;

                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(pokemons[0]);

                    IncreasingAndDecreasing(pokemons, removedNumber);
                }
            }

            Console.WriteLine(sumOfRemovedNumbers);
        }

        private static void IncreasingAndDecreasing(List<int> pokemons, int removedNumber)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= removedNumber)
                {
                    pokemons[i] = pokemons[i] + removedNumber;
                }
                else
                {
                    pokemons[i] = pokemons[i] - removedNumber;
                }
            }
        }
    }
}
