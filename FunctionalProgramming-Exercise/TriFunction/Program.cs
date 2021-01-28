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
            Func<string, int, bool> myWhere = (name, n) => name.Length >= n;
            
            

          
        }
    }
}
