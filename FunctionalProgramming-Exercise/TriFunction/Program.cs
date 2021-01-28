using System;
using System.IO;
using System.Linq;

namespace TriFunction
{
    static class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> privateWhere = (name, n) => name.ToCharArray().Select(x => (int)x).Sum() >= n;

            Func<string[], string> getFirstValidName = names =>
            {
                var name = string.Empty;
                foreach (var currentName in names)
                {
                    if (privateWhere(currentName, n))
                    {
                        name = currentName;
                        break;
                    }
                }

                return name;
            };

            Console.WriteLine(getFirstValidName(names));
        }
    }
}
