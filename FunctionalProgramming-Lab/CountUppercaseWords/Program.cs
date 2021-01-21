using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            Func<string, bool> func = x => char.IsUpper(x[0]);
            var words = text.Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(x => func(x));
            Console.WriteLine(string.Join(Environment.NewLine,words));                   
        }
    }
}
