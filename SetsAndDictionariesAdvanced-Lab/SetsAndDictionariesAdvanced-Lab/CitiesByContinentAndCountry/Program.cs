using System;
using System.Collections.Generic;
using System.Linq;


namespace CitiesByContinentAndCountry
{
    static class Program
    {
        static void Main(string[] args)
        {
            var dictContinentCountryCities = new Dictionary<string, Dictionary<string, List<string>>>();
            int totalNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < totalNum; i++)
            {
                string[] names = Console.ReadLine().Split().ToArray();
                string continent = names[0];
                string country = names[1];
                string city = names[2];
                if (!dictContinentCountryCities.ContainsKey(continent))
                {
                    dictContinentCountryCities[continent] = new Dictionary<string, List<string>>();
                    dictContinentCountryCities[continent].Add(country, new List<string>());
                    dictContinentCountryCities[continent][country].Add(city);
                }

                else if (dictContinentCountryCities.ContainsKey(continent))
                {
                    if (!dictContinentCountryCities[continent].ContainsKey(country))
                    {
                        dictContinentCountryCities[continent].Add(country, new List<string>());
                        dictContinentCountryCities[continent][country].Add(city);
                    }

                    else if (dictContinentCountryCities[continent].ContainsKey(country))
                    {
                        dictContinentCountryCities[continent][country].Add(city);
                    }
                }
            }

            foreach (var (continent, countryCities) in dictContinentCountryCities)
            {
                Console.WriteLine($"{continent}:");
                foreach (var (country, cities) in countryCities)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
