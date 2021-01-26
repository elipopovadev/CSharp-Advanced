using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().ToArray();
            Func<int, string[], string[]> func = (length, names) =>
              {
                  var newList = new List<string>();
                  foreach (var name in names)
                  {
                      if(name.Length <= length)
                      {
                          newList.Add(name);
                      }
                  }

                  return newList.ToArray();
              };

            var newNames = func(length, names);
            Console.WriteLine(string.Join(Environment.NewLine, newNames));
        }
    }
}
