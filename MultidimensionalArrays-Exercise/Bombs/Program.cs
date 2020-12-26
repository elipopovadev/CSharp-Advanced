using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int[,] matrix = new int[rows, cols];
            ReadTheMatrix(rows, cols, matrix);

            string[] allBombsCoordinates = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < allBombsCoordinates.Length; i++)
            {
                int[] currentBombCoordinates = allBombsCoordinates[i].Split(',').Select(int.Parse).ToArray();
                int rowCurrentBomb = currentBombCoordinates[0];
                int colCurrentBomb = currentBombCoordinates[1];
                int bombCurrentValue = 0;
                if (rowCurrentBomb >= 0 && rowCurrentBomb < rows && colCurrentBomb >= 0 && colCurrentBomb < cols) // validate the bomb coordinates
                {
                    bombCurrentValue = matrix[rowCurrentBomb, colCurrentBomb];
                }

                if (bombCurrentValue > 0)
                {
                    CheckHowTheBombEffectThePreviousRow(cols, matrix, rowCurrentBomb, colCurrentBomb, bombCurrentValue);
                    CheckHowTheBombEffectTheLeftAndTheRightSideOnTheSameRow(cols, matrix, rowCurrentBomb, colCurrentBomb, bombCurrentValue);
                    CheckHowTheBombEffectTheNextRow(rows, cols, matrix, rowCurrentBomb, colCurrentBomb, bombCurrentValue);
                    matrix[rowCurrentBomb, colCurrentBomb] = 0;
                }
            }

            int countAliveCells = 0;
            int sumAliveCells = 0;
            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    countAliveCells++;
                    sumAliveCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {countAliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            PrintTheMatrix(matrix);
        }

        private static void ReadTheMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintTheMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");

                }

                Console.WriteLine();
            }
        }

        private static void CheckHowTheBombEffectTheNextRow(int rows, int cols, int[,] matrix, int rowCurrentBomb, int colCurrentBomb, int bombCurrentValue)
        {
            if (rowCurrentBomb + 1 < rows && colCurrentBomb - 1 >= 0)
            {
                if (matrix[rowCurrentBomb + 1, colCurrentBomb - 1] > 0)
                {
                    matrix[rowCurrentBomb + 1, colCurrentBomb - 1] -= bombCurrentValue;
                }
            }

            if (rowCurrentBomb + 1 < rows)
            {
                if (matrix[rowCurrentBomb + 1, colCurrentBomb] > 0)
                {
                    matrix[rowCurrentBomb + 1, colCurrentBomb] -= bombCurrentValue;
                }
            }

            if (rowCurrentBomb + 1 < rows && colCurrentBomb + 1 < cols)
            {
                if (matrix[rowCurrentBomb + 1, colCurrentBomb + 1] > 0)
                {
                    matrix[rowCurrentBomb + 1, colCurrentBomb + 1] -= bombCurrentValue;
                }
            }
        }

        private static void CheckHowTheBombEffectTheLeftAndTheRightSideOnTheSameRow(int cols, int[,] matrix, int rowCurrentBomb, int colCurrentBomb, int bombCurrentValue)
        {
            if (colCurrentBomb - 1 >= 0)
            {
                if (matrix[rowCurrentBomb, colCurrentBomb - 1] > 0)
                {
                    matrix[rowCurrentBomb, colCurrentBomb - 1] -= bombCurrentValue;
                }
            }

            if (colCurrentBomb + 1 < cols)
            {
                if (matrix[rowCurrentBomb, colCurrentBomb + 1] > 0)
                {
                    matrix[rowCurrentBomb, colCurrentBomb + 1] -= bombCurrentValue;
                }
            }
        }

        private static void CheckHowTheBombEffectThePreviousRow(int cols, int[,] matrix, int rowCurrentBomb, int colCurrentBomb, int bombCurrentValue)
        {
            if (rowCurrentBomb - 1 >= 0 && colCurrentBomb - 1 >= 0)
            {
                if (matrix[rowCurrentBomb - 1, colCurrentBomb - 1] > 0)
                {
                    matrix[rowCurrentBomb - 1, colCurrentBomb - 1] -= bombCurrentValue;
                }
            }

            if (rowCurrentBomb - 1 >= 0)
            {
                if (matrix[rowCurrentBomb - 1, colCurrentBomb] > 0)
                {
                    matrix[rowCurrentBomb - 1, colCurrentBomb] -= bombCurrentValue;
                }
            }

            if (rowCurrentBomb - 1 >= 0 && colCurrentBomb + 1 < cols)
            {
                if (matrix[rowCurrentBomb - 1, colCurrentBomb + 1] > 0)
                {
                    matrix[rowCurrentBomb - 1, colCurrentBomb + 1] -= bombCurrentValue;
                }
            }
        }
    }
}
