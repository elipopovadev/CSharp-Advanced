using System;
using System.Linq;
using System.Collections.Generic;


namespace Snowwhite_withClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictHatColourDwarf = new Dictionary<string, List<Dwarf>>();
            string input;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputArray = input.Split(" <:> ");
                string name = inputArray[0];
                string hatColour = inputArray[1];
                int physic = int.Parse(inputArray[2]);
                if (!dictHatColourDwarf.ContainsKey(hatColour))
                {
                    Dwarf newDwarf = CreateNewDworf(name, hatColour, physic);
                    dictHatColourDwarf[hatColour] = new List<Dwarf>();
                    dictHatColourDwarf[hatColour].Add(newDwarf);
                }

                else if (dictHatColourDwarf.ContainsKey(hatColour) && !dictHatColourDwarf[hatColour].Any(x => x.Name == name))
                {
                    Dwarf newDwarf = CreateNewDworf(name, hatColour, physic);
                    dictHatColourDwarf[hatColour].Add(newDwarf);
                }

                else if (dictHatColourDwarf.ContainsKey(hatColour) && dictHatColourDwarf[hatColour].Any(x => x.Name == name))
                {
                    var findDwarf = dictHatColourDwarf[hatColour].First(x => x.Name == name);
                    if (findDwarf.Physic < physic)
                    {
                        findDwarf.Physic = physic;
                    }
                }
            }

            PrintSortedDwarfs(dictHatColourDwarf);
        }

        private static Dwarf CreateNewDworf(string name, string hatColour, int physic)
        {
            Dwarf newDwarf = new Dwarf(hatColour);
            newDwarf.HatColour = hatColour;
            newDwarf.Name = name;
            newDwarf.Physic = physic;
            return newDwarf;
        }

        private static void PrintSortedDwarfs(Dictionary<string, List<Dwarf>> dictHatColourDwarf)
        {
            var sortedDictByHatColour = new Dictionary<string, int>();
            foreach (var (hatColour, listOfDwarfs) in dictHatColourDwarf.OrderByDescending(x => x.Value.Count))
            {
                foreach (var dwarf in listOfDwarfs)
                {
                    sortedDictByHatColour.Add($"({hatColour}) {dwarf.Name} <-> ", dwarf.Physic);

                }
            }

            foreach (var (hatColorWithName, physic) in sortedDictByHatColour.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{hatColorWithName}{physic}");
            }
        }
    }


    public class Dwarf
    {
        public string HatColour { get; set; }
        public string Name { get; set; }
        public int Physic { get; set; }

        public Dwarf(string hatColour)
        {
            this.HatColour = hatColour;
            this.Name = Name;
            this.Physic = Physic;
        }
    }
}
