using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, string, string, List<string>> funcAddFilter = (guests, filterType, filterParameter) =>
            {
                var newList = new List<string>();
                if (filterType == "Starts with")
                {
                    foreach (var person in guests)
                    {
                        if (!person.StartsWith(filterParameter)) newList.Add(person);
                    }
                }

                else if (filterType == "Ends with")
                {
                    foreach (var person in guests)
                    {
                        if (!person.EndsWith(filterParameter)) newList.Add(person);
                    }
                }

                else if (filterType == "Length")
                {
                    int length = int.Parse(filterParameter);
                    foreach (var person in guests)
                    {
                        if (person.Length != length) newList.Add(person);
                    }

                }

                else if (filterType == "Contains")
                {
                    foreach (var person in guests)
                    {
                        if (!person.Contains(filterParameter)) newList.Add(person);
                    }
                }

                return newList;
            };

            var guests = Console.ReadLine().Split().ToList();
            var listWithFilter = new List<Filter>();
            var listWithConditions = new List<List<string>>();
            listWithConditions.Add(guests);

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] inputArray = input.Split(';').ToArray();
                string command = inputArray[0];
                string filterType = inputArray[1];
                string filterParameter = inputArray[2];
                if (command.StartsWith("Add"))
                {
                    guests = funcAddFilter(guests, filterType, filterParameter);
                    var newFilter = new Filter(filterType, filterParameter);
                    listWithFilter.Add(newFilter);
                    listWithConditions.Add(guests);
                }

                else if (command.StartsWith("Remove"))
                {
                    listWithConditions.RemoveAt(listWithConditions.Count - 1);
                    listWithFilter.RemoveAt(listWithConditions.Count-1);
                    
                }
            }

            var lastCondition = listWithConditions.Last();
            Console.WriteLine(string.Join(" ", lastCondition));
        }
    }

    class Filter
    {
        public Filter(string filterType, string filterParameter)
        {
            this.FilterType = filterType;
            this.FilterParameter = filterParameter;
        }
        public string FilterType { get; set; }
        public string FilterParameter { get; set; }
    }
}
