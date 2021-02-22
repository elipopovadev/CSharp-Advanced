using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {      
        static void Main(string[] args)
        {
            var listOfBoxes = new List<Box<double>>();
            int numberOfBoxes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfBoxes; i++)
            {
                double number = double.Parse(Console.ReadLine());
                var newBox = new Box<double>(number);
                listOfBoxes.Add(newBox);
            }

            double Othernumber = double.Parse(Console.ReadLine());
            var elementToCompare = new Box<double>(Othernumber);
            int count = CauntGreaterElementsThanValue(listOfBoxes, elementToCompare);
            Console.WriteLine(count);
        }


        public static int CauntGreaterElementsThanValue<T>(List<T> listOfboxes,T elementToCompare)
            where T: IComparable<T>
        {
            int count = 0;
            foreach (var box in listOfboxes)
            {
                if(box.CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }        
    }
}
