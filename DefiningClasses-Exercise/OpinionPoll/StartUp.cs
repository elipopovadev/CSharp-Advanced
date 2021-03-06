﻿using System;
using System.Linq;

namespace OpinionPoll
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            var register = new Register();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] personArray = Console.ReadLine().Split();
                string name = personArray[0];
                int age = int.Parse(personArray[1]);
                var newPerson = new Person(name, age);
                register.AddPerson(newPerson);
            }

            var listOrderByAge = register.GetOldersThanThirty();
            var sortFilterList = listOrderByAge.OrderBy(x => x.Name);
            foreach (var person in sortFilterList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}

