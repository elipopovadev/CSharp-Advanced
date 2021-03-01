using System;
using System.Collections.Generic;
using System.IO;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();
            int numberOfPersons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(name, age);
                sortedSet.Add(newPerson);
                hashSet.Add(newPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
