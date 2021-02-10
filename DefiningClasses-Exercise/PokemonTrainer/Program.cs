using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program    
    {
        static void Main(string[] args)
        {
            var listWithTrainers = new List<Trainer>();
            string firstCommand;
            while ((firstCommand = Console.ReadLine()) != "Tournament")
            {
                string[] inputArray = firstCommand.Split();
                string trainerName = inputArray[0];
                string pokemonName = inputArray[1];
                string pokemonElement = inputArray[2];
                int pokemonHealth = int.Parse(inputArray[3]);

                var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!listWithTrainers.Any(t => t.Name == trainerName))
                {
                    var newTrainer = new Trainer(trainerName);
                    newTrainer.AddPokemon(newPokemon);
                    listWithTrainers.Add(newTrainer);
                }

                else
                {
                    var findedTrainer = listWithTrainers.Where(t => t.Name == trainerName).First();
                    findedTrainer.AddPokemon(newPokemon);
                }
            }

            string secondCommand;
            while ((secondCommand = Console.ReadLine()) != "End")
            {
                string element = secondCommand;
                if (element == "Fire")
                {
                    foreach (var trainer in listWithTrainers)
                    {
                        trainer.CheckTrainerForAddBadge(element);
                        trainer.CheckTrainerForReduceHealth(element);
                    }
                }

                else if (element == "Water")
                {
                    foreach (var trainer in listWithTrainers)
                    {
                        trainer.CheckTrainerForAddBadge(element);
                        trainer.CheckTrainerForReduceHealth(element);
                    }
                }

                else if (element == "Electricity")
                {
                    foreach (var trainer in listWithTrainers)
                    {
                        trainer.CheckTrainerForAddBadge(element);
                        trainer.CheckTrainerForReduceHealth(element);
                    }
                }

                foreach (var trainer in listWithTrainers)
                {
                    trainer.CheckTrainerForDeadPokemons();
                }
            }

            SortAndPrintResult(listWithTrainers);
        }


        private static void SortAndPrintResult(List<Trainer> listWithTrainers)
        {
            foreach (var trainer in listWithTrainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemon.Count}");
            }
        }
    }
}
