using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfBoxes = new List<Box<string>>();
            int numberOfElements = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfElements; i++)
            {
                string element = Console.ReadLine();
                var newBox = new Box<string>(element);
                listOfBoxes.Add(newBox);
            }

            string elementForCompared = Console.ReadLine();
            var BoxOfElementToCompare = new Box<string>(elementForCompared);
            int count = CountGreaterValues(listOfBoxes, BoxOfElementToCompare);
            Console.WriteLine(count);
        }


        public static int CountGreaterValues<T>(List<T> list, T elementToCompare)
            where T : IComparable<T>
        {
            int count = 0;
            foreach (var box in list)
            {
                if (box.CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
