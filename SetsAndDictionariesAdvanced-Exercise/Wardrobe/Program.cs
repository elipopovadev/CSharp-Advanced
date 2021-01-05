using System;
using System.Collections.Generic;

namespace Wardrobe
{
    static class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());   
            var dictColorClothesCount = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];
                string[] secondPartWithClothes = input[1].Split(',');
                foreach (var cloth in secondPartWithClothes)
                {
                    if (!dictColorClothesCount.ContainsKey(colour))
                    {
                        dictColorClothesCount[colour] = new Dictionary<string, int>();
                        dictColorClothesCount[colour].Add(cloth, 1);
                    }

                    else if (dictColorClothesCount.ContainsKey(colour))
                    {
                        if (!dictColorClothesCount[colour].ContainsKey(cloth))
                        {
                            dictColorClothesCount[colour].Add(cloth, 0);
                        }

                        dictColorClothesCount[colour][cloth]++;
                    }
                }
            }

            string[] inputLookingFor = Console.ReadLine().Split();
            string colorLookingFor = inputLookingFor[0];
            string clothLookingFor = inputLookingFor[1];
            foreach (var (color, clothesCount) in dictColorClothesCount)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (cloth, count) in clothesCount)
                {
                    Console.WriteLine(color != colorLookingFor || cloth != clothLookingFor
                        ? $"* {cloth} - {count}"
                        : $" * {cloth} - {count} (found!)");
                }
            }
        }
    }
}
