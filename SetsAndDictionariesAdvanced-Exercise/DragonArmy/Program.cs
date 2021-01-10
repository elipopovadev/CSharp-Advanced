using System;
using System.Linq;
using System.Collections.Generic;

namespace DragonArmy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictTypeDragons = new Dictionary<string, List<Dragon>>();
            int numbeOfDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbeOfDragons; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string name = input[1];
                string damage = input[2];
                string health = input[3];
                string armor = input[4];
                if (!dictTypeDragons.ContainsKey(type))
                {
                    Dragon newDragon = CreateNewDragon(type, name, damage, health, armor);
                    dictTypeDragons.Add(type, new List<Dragon>());
                    dictTypeDragons[type].Add(newDragon);
                }

                else if (dictTypeDragons.ContainsKey(type) && !dictTypeDragons[type].Any(d => d.Name == name))
                {
                    Dragon newDragon = CreateNewDragon(type, name, damage, health, armor);
                    dictTypeDragons[type].Add(newDragon);
                }

                else if (dictTypeDragons.ContainsKey(type) && dictTypeDragons[type].Any(d => d.Name == name))
                {
                    Dragon findDragonToUpdate = dictTypeDragons[type].First(d => d.Name == name);
                    dictTypeDragons[type].Remove(findDragonToUpdate);
                    Dragon newDragon = CreateNewDragon(type, name, damage, health, armor);
                    dictTypeDragons[type].Add(newDragon);
                }
            }

            foreach (var (type, listOfDragons) in dictTypeDragons)
            {
                double averageDamage = CalculateAverageDamage(dictTypeDragons, type);
                double averageHealth = CalculateAverageHealth(dictTypeDragons, type);
                double averageArmor = CalculateAverageArmor(dictTypeDragons, type);
                Console.WriteLine($"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");
                foreach (var dragon in listOfDragons.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }


        private static double CalculateAverageArmor(Dictionary<string, List<Dragon>> dictTypeDragons, string type)
        {
            return dictTypeDragons[type].Select(x => x.Armor).Select(x => int.Parse(x)).ToList().Sum() > 0 ?
                   dictTypeDragons[type].Select(x => x.Armor).Select(x => int.Parse(x)).ToList().Average() : 0;
        }

        private static double CalculateAverageHealth(Dictionary<string, List<Dragon>> dictTypeDragons, string type)
        {
            return dictTypeDragons[type].Select(x => x.Health).Select(x => int.Parse(x)).ToList().Sum() > 0 ?
                   dictTypeDragons[type].Select(x => x.Health).Select(x => int.Parse(x)).ToList().Average() : 0;
        }

        private static double CalculateAverageDamage(Dictionary<string, List<Dragon>> dictTypeDragons, string type)
        {
            return dictTypeDragons[type].Select(x => x.Damage).Select(x => int.Parse(x)).ToList().Sum() > 0 ?
                   dictTypeDragons[type].Select(x => x.Damage).Select(x => int.Parse(x)).ToList().Average() : 0;
        }

        private static Dragon CreateNewDragon(string type, string name, string damage, string health, string armor)
        {
            Dragon newDragon = new Dragon(name);
            newDragon.Type = type;
            newDragon.Name = name;
            newDragon.Damage = damage;
            newDragon.Health = health;
            newDragon.Armor = armor;

            if (newDragon.Damage == "null")
            {
                newDragon.Damage = "45";
            }

            if (newDragon.Health == "null")
            {
                newDragon.Health = "250";
            }

            if (newDragon.Armor == "null")
            {
                newDragon.Armor = "10";
            }

            return newDragon;
        }
    }

    class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string Health { get; set; }
        public string Armor { get; set; }

        public Dragon(string Name)
        {
            this.Name = Name;
            this.Type = Type;
            this.Damage = Damage;
            this.Health = Health;
            this.Armor = Armor;
        }
    }
}