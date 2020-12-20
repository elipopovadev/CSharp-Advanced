using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int countEqualSquares = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {

                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1] &&
                        matrix[row, col]== matrix[row + 1, col])                       
                    {
                        countEqualSquares++;
                    }
                }
            }

            Console.WriteLine(countEqualSquares);
        }
    }
}

