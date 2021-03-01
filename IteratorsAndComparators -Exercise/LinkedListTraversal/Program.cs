using System;

namespace LinkedListTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<int>();
            int numberOfCommand = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] commandArray = Console.ReadLine().Split();
                string command = commandArray[0];
                int value = int.Parse(commandArray[1]);
                if (command == "Add")
                {
                    doublyLinkedList.Add(value);
                }

                else if (command == "Remove")
                {
                    doublyLinkedList.Remove(value);
                }
            }

            Console.WriteLine(doublyLinkedList.Count);
            foreach (var nodeValue in doublyLinkedList)
            {
                Console.Write(nodeValue+" ");
            }          
        }
    }
}
