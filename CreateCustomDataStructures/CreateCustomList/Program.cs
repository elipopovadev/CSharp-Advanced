using System;

namespace CreateCustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList();
            customList.Add(1);
            Console.WriteLine(customList.Count);
            customList.Add(2);
            Console.WriteLine(customList.Count);
            Console.WriteLine();
            customList.Add(3);
            customList.Add(4);
            Console.WriteLine(customList.Count);
            
            
        }
    }
}
