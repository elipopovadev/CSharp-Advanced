using System;

namespace CreateLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var newLinkedList = new LinkedList<int>();
            newLinkedList.AddFirst(1);
            newLinkedList.RemoveFirst();
            newLinkedList.AddLast(2);
            newLinkedList.AddFirst(1);
            newLinkedList.RemoveLast();

            var array = newLinkedList.ToArray();
            foreach (var item in array)
            {
                Console.WriteLine(item); // 1
            }
            Console.WriteLine($"Count {newLinkedList.Count}"); // 1
        }
    }
}
