using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    for (int subrow = row + 0; subrow < row + 3; subrow++)
                    {
                        for (int subcol = col + 0; subcol < col + 3; subcol++)
                        {
                            sum += matrix[subrow, subcol];
                            if (sum > maxSum)
                            {
                                maxSum = sum;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
            }


            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[maxRow + i, maxCol + j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

