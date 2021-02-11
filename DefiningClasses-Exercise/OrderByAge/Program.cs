using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderByAge
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArray[0];
                string ID = inputArray[1];
                int age = int.Parse(inputArray[2]);
                var newPerson = new Person(name, ID, age);
                listOfPeople.Add(newPerson);
            }

            foreach (var person in listOfPeople.OrderBy(p => p.Age))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

    class Person
    {
        public Person(string name, string ID, int age)
        {
            this.Name = name;
            this.ID = ID;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Name} with ");
            sb.Append($"ID: {this.ID} is ");
            sb.AppendLine($"{this.Age} years old.");
            return sb.ToString().Trim();
        }
    }
}
