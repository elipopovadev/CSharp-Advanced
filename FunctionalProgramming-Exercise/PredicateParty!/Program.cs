using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var listWithGuests = Console.ReadLine().Split().ToList();
            Func<List<string>, string, string, List<string>> funcRemoveByString = (list, condition, letters) =>
              {
                  var newList = new List<string>();
                  foreach (var person in list)
                  {
                      if (condition == "StartsWith" && !person.StartsWith(letters))
                      {
                          newList.Add(person);
                      }

                      else if (condition == "EndsWith" && !person.EndsWith(letters))
                      {
                          newList.Add(person);
                      }
                  }

                  return newList;
              };

            Func<List<string>, string, string, List<string>> funcDoubleByString = (list, condition, letters) =>
            {
                var newList = new List<string>();
                foreach (var person in list)
                {
                    if (condition == "StartsWith")
                    {
                        newList.Add(person);
                        if (person.StartsWith(letters)) newList.Add(person);
                    }

                    else if (condition == "EndsWith")
                    {
                        newList.Add(person);
                        if (person.EndsWith(letters)) newList.Add(person);
                    }
                }

                return newList;
            };

            Func<List<string>, string, int, List<string>> funcOperationByLength = (list, condition, length) =>
             {
                 var newList = new List<string>();
                 foreach (var person in list)
                 {
                     if (condition == "Remove" && person.Length != length)
                     {
                         newList.Add(person);
                     }

                     else if (condition == "Double")
                     {
                         newList.Add(person);
                         if (person.Length == length) newList.Add(person);
                     }
                 }

                 return newList;
             };

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                if (command.StartsWith("Remove") && !command.Contains("Length"))
                {
                    string[] commandArray = command.Split();
                    string condition = commandArray[1]; // StartsWith or EndsWith
                    string letters = commandArray[2];
                    listWithGuests = funcRemoveByString(listWithGuests, condition, letters);
                }

                else if (command.StartsWith("Double") && !command.Contains("Length"))
                {
                    string[] commandArray = command.Split();
                    string condition = commandArray[1]; // StartsWith or EndsWith
                    string letters = commandArray[2];
                    listWithGuests = funcDoubleByString(listWithGuests, condition, letters);
                }

                else if (command.Contains("Length"))
                {
                    string[] commandArray = command.Split();
                    string condition = commandArray[0]; // Double or Remove
                    int length = int.Parse(commandArray[2]);
                    listWithGuests = funcOperationByLength(listWithGuests, condition, length);
                }
            }

            if (listWithGuests.Count > 0)
            {
                Console.Write(string.Join(", ", listWithGuests));
                Console.WriteLine(" are going to the party!");
            }

            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
