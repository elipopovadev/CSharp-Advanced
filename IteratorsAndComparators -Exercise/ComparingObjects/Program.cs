using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var listWithPeople = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] person = input.Split();
                string name = person[0];
                int age = int.Parse(person[1]);
                string town = person[2];
                var newPerson = new Person(name, age, town);
                listWithPeople.Add(newPerson);
            }

            int indexToComparing = int.Parse(Console.ReadLine());
            if(indexToComparing >= 0 && indexToComparing < listWithPeople.Count)
            {
                var personToComparing = listWithPeople[indexToComparing];
                int countForEqualPeople = 0;
                foreach (var person in listWithPeople)
                {
                    if (person.CompareTo(personToComparing) == 0)
                    {
                        countForEqualPeople++;
                    }
                }

                int countForUnequalPeople = listWithPeople.Count - countForEqualPeople;
                Console.WriteLine($"{countForEqualPeople} {countForUnequalPeople} {listWithPeople.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
