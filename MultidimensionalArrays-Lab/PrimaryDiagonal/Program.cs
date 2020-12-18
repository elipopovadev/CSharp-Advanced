using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            int sumDiagonal = 0;

            for (int row = 0; row < sizeMatrix ; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (row == col)
                    {
                        sumDiagonal += matrix[row, col];
                    }                
                }
            }

            Console.WriteLine(sumDiagonal);
        }
    }
}
