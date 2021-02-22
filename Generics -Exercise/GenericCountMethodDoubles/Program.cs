using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfBoxes = new List<Box<double>>();
            int numberOfElements = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfElements; i++)
            {
                double doubleNumber = double.Parse(Console.ReadLine());
                var newBox = new Box<double>(doubleNumber);
                listOfBoxes.Add(newBox);
            }
            double numberToCompare = double.Parse(Console.ReadLine());
            var BoxOfNumberToCompare = new Box<double>(numberToCompare);
            int count= CountGreaterValues(listOfBoxes, BoxOfNumberToCompare);
            Console.WriteLine(count);
        }

        public static int CountGreaterValues<T>(List<T> listWithBoxes, T BoxOfNumberToCompare)
            where T:IComparable<T>
        {
            int count = 0;
            foreach (var box in listWithBoxes)
            {
                if(box.CompareTo(BoxOfNumberToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
