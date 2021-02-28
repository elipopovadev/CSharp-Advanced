using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSetByName = new SortedSet<Person>(new ComparatorByName());
            SortedSet<Person> sortedSetByAge = new SortedSet<Person>(new ComparatorByAge());
         
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(name, age);
                sortedSetByName.Add(newPerson);
                sortedSetByAge.Add(newPerson);                   
            }

            foreach (var person in sortedSetByName)
            {
                Console.WriteLine(person.Name + " "+ person.Age);
            }

            foreach (var person in sortedSetByAge)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }
    }
}
