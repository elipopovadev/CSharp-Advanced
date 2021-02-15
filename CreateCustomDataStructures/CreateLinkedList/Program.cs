using System;

namespace CreateLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var newLinkedList = new LinkedList();
            newLinkedList.AddFirst(1);
            newLinkedList.AddLast(2);
            var array = newLinkedList.ToArray();
            foreach (var item in array)
            {
                Console.WriteLine(item);

            }
        }
    }
}
