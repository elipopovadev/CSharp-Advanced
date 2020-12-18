using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
       
            int maxSum = int.MinValue;
            int maxRow = int.MinValue;
            int maxCol = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = 0;
                    for (int subrow = 0; subrow < 2; subrow++)
                    {
                        for (int subcol = 0; subcol < 2; subcol++)
                        {
                            sum += matrix[row + subrow, col + subcol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int subrow = 0; subrow < 2; subrow++)
            {
                for (int subcol = 0; subcol < 2; subcol++)
                {
                    Console.Write($"{matrix[maxRow + subrow, maxCol + subcol]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
