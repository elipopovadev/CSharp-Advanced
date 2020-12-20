using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int sumPrimaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumPrimaryDiagonal += matrix[row, col];
                    }
                }
            }

            int sumSecondaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    col = (matrix.GetLength(1) -1) - row;
                    sumSecondaryDiagonal += matrix[row, col];
                    break;
                }
            }

            if (sumPrimaryDiagonal != sumSecondaryDiagonal)
            {
                int maxSumDiagonal = Math.Max(sumPrimaryDiagonal, sumSecondaryDiagonal);
                int minSumDiagonal = Math.Min(sumPrimaryDiagonal, sumSecondaryDiagonal);
                int difference = maxSumDiagonal - minSumDiagonal;
                int absoluteDifference = Math.Abs(difference);
                Console.WriteLine(absoluteDifference);
            }

            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
