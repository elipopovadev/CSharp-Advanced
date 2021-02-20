using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Box<int>>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                int data = int.Parse(Console.ReadLine());
                var newBox = new Box<int>(data);
                list.Add(newBox);
            }

            int[] swapCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];
            SwapMethod(list, firstIndex, secondIndex);
            foreach (var box in list)
            {
                Console.WriteLine(box.ToString());
            }
        }


        public static void SwapMethod<T>(List<T> list, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= list.Count || secondIndex < 0 || secondIndex >= list.Count)
            {
                throw new InvalidOperationException("Invalid index!");
            }

            T firstData = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstData;
        }
    }
}
