using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    static class Program
    {
        static void Main(string[] args)
        {
            int totalNum = int.Parse(Console.ReadLine());
            var hashSetUniqueNames = new HashSet<string>();
            for (int i = 0; i < totalNum; i++)
            {
                string name = Console.ReadLine();
                hashSetUniqueNames.Add(name);
            }

            foreach (string name in hashSetUniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
