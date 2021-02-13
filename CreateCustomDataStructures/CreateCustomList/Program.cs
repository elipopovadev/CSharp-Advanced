using System;

namespace CreateCustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList();
            customList.Add(1);
            customList.Add(2);
            customList.Insert(2,10);
            customList.Insert(1,100);
            customList.RemoveAt(2);
            customList.Swap(1,2);
            Console.WriteLine(string.Join(" ",customList));  // 1 100 10         
        }
    }
}
