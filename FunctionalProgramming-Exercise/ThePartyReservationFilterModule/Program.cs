using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialList = Console.ReadLine().Split().ToList();

            Func<List<string>, string, string, List<string>> funcRemoveFilter = (initialList, filterType, filterParameter) =>
            {
                var listOnlyWithRemovedFilter = new List<string>();
                if (filterType == "Starts with")
                {
                    foreach (var person in initialList)
                    {
                        if (person.StartsWith(filterParameter)) listOnlyWithRemovedFilter.Add(person);
                    }
                }

                else if (filterType == "Ends with")
                {
                    foreach (var person in initialList)
                    {
                        if (person.EndsWith(filterParameter)) listOnlyWithRemovedFilter.Add(person);
                    }
                }

                else if (filterType == "Length")
                {
                    int length = int.Parse(filterParameter);
                    foreach (var person in initialList)
                    {
                        if (person.Length == length) listOnlyWithRemovedFilter.Add(person);
                    }
                }

                else if (filterType == "Contains")
                {
                    foreach (var person in initialList)
                    {
                        if (person.Contains(filterParameter)) listOnlyWithRemovedFilter.Add(person);
                    }
                }

                return listOnlyWithRemovedFilter;
            };

            Func<List<string>, string, string, List<string>> funcAddFilter = (guests, filterType, filterParameter) =>
            {
                var listWithFilter = new List<string>();
                if (filterType == "Starts with")
                {
                    foreach (var person in guests)
                    {
                        if (!person.StartsWith(filterParameter)) listWithFilter.Add(person);
                    }
                }

                else if (filterType == "Ends with")
                {
                    foreach (var person in guests)
                    {
                        if (!person.EndsWith(filterParameter)) listWithFilter.Add(person);
                    }
                }

                else if (filterType == "Length")
                {
                    int length = int.Parse(filterParameter);
                    foreach (var person in guests)
                    {
                        if (person.Length != length) listWithFilter.Add(person);
                    }
                }

                else if (filterType == "Contains")
                {
                    foreach (var person in guests)
                    {
                        if (!person.Contains(filterParameter)) listWithFilter.Add(person);
                    }
                }

                return listWithFilter;
            };

            string input;
            var guests = new List<string>();
            guests.AddRange(initialList);
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] inputArray = input.Split(';').ToArray();
                string command = inputArray[0];
                string filterType = inputArray[1];
                string filterParameter = inputArray[2];
                if (command.StartsWith("Add"))
                {
                    guests = funcAddFilter(guests, filterType, filterParameter);
                }

                else if (command.StartsWith("Remove"))
                {
                    var listOnlyWithRemoveFilter = funcRemoveFilter(initialList, filterType, filterParameter);
                    guests.AddRange(listOnlyWithRemoveFilter);
                }
            }

            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
