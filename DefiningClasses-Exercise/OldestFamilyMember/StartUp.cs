using System;
using System.IO;
using System.Collections.Generic;

namespace OldestFamilyMember
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            var family = new Family();
            int numberOfMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfMembers; i++)
            {
                string[] personArray = Console.ReadLine().Split();
                string name = personArray[0];
                int age = int.Parse(personArray[1]);
                Person newPerson = new Person(name, age);
                family.AddMember(newPerson);                                          
            }

            var oldestMember=family.GetOldestMember();
            Console.Write($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
