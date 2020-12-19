using System;
using System.Linq;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                pascalTriangle[i] = new long[i + 1]; // every array.Length = i+1 and there are no Null
            }

            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                pascalTriangle[row][0] = 1; // the first element is always 1;
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1; // the last element is always 1;
                for (int col = 1; col < pascalTriangle[row].Length - 1; col++) // work only with middle elements
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }
            }

            foreach (long[] array in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}