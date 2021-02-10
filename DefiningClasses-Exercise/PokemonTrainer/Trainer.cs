using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.CollectionOfPokemon = new List<Pokemon>();
        }

        public Trainer(string name, List<Pokemon> collectionOfPokemon)
            :this(name)
        {
            this.NumberOfBadges = 0;
            this.CollectionOfPokemon = collectionOfPokemon;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemon { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {                     
            this.CollectionOfPokemon.Add(pokemon);
        }

        public void CheckTrainerForAddBadge(string element)
        {
            if (this.CollectionOfPokemon.Any(p => p.Element == element))
            {
                this.NumberOfBadges++;
            }
        }
        
        public void CheckTrainerForReduceHealth(string element)
        {
            if (!this.CollectionOfPokemon.Any(p => p.Element == element))
            {
                foreach (Pokemon pokemon in this.CollectionOfPokemon)
                {
                    pokemon.Health -= 10;
                }
            }
        }

        public void CheckTrainerForDeadPokemons()
        {
            this.CollectionOfPokemon = this.CollectionOfPokemon.Where(pokemon => pokemon.Health > 0).ToList();
        }
    }
}
