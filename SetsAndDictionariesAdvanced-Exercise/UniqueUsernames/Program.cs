using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    static class Program
    {
        static void Main(string[] args)
        {           
            int number = int.Parse(Console.ReadLine());
            var setWithUserNames = new HashSet<string>();
            for (int i = 0; i < number; i++)
            {
                string userName = Console.ReadLine();
                setWithUserNames.Add(userName);
            }

            Console.WriteLine(string.Join(Environment.NewLine, setWithUserNames));
        }
    }
}
