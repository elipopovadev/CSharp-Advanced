using System;

namespace CreateDoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var newList = new DoublyLinkedList();
            newList.AddFirst(2);
            newList.AddFirst(1);
            newList.AddLast(3);
            newList.AddLast(4);
            newList.AddFirst(5);
            newList.AddLast(6);
            newList.RemoveFirst();
            newList.RemoveFirst();
            newList.RemoveLast();
            newList.RemoveLast();
            var newArray = newList.ToArray(); // 2 3
            Console.WriteLine(newArray.Length); // 2
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
