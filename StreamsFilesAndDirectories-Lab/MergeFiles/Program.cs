using System;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = File.ReadAllLines(@"..\..\..\input1.txt").ToList();
            list.AddRange(File.ReadAllLines(@"..\..\..\input2.txt"));
            list.OrderBy(x=>x);
            File.WriteAllLines(@"..\..\..\output.txt", list);
        }
    }
}
