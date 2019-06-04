namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Tournament")
                {
                    break;
                }
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Exists(x => x.Name == trainerName))
                {
                    int currentTrainerIndex = trainers.FindIndex(x => x.Name == trainerName);
                    trainers[currentTrainerIndex].CollectionOfPokemon.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, pokemon);
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.CollectionOfPokemon.Exists(x => x.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.CollectionOfPokemon.ForEach(x => x.Health -= 10);
                        trainer.CollectionOfPokemon.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.CollectionOfPokemon.Count}");
            }
        }
    }
}