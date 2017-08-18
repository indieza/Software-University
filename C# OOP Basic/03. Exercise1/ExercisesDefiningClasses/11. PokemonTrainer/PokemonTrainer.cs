using System;
using System.Collections.Generic;
using System.Linq;

internal class PokemonTrainer
{
    private static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

        while (line != "Tournament")
        {
            string[] items = line.Split();
            string trainerName = items[0];
            string pokemonName = items[1];
            string pokemonElement = items[2];
            int pokemonHealth = int.Parse(items[3]);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName, new Trainer(trainerName));
            }

            trainers[trainerName].AddPokemon(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

            line = Console.ReadLine();
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string element = command;

            foreach (var trainer in trainers.Values)
            {
                trainer.AddBadge(element);
            }

            command = Console.ReadLine();
        }

        List<Trainer> result = trainers.Values.OrderByDescending(trainer => trainer.NumberOfBadges).ToList();

        Console.WriteLine(string.Join("\n", result));
    }
}