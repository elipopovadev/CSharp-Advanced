using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandArray[0] == "swap" &&
                   int.TryParse(commandArray[1], out int row1) &&
                   int.TryParse(commandArray[2], out int col1) &&
                   int.TryParse(commandArray[3], out int row2) &&
                   int.TryParse(commandArray[4], out int col2) &&
                   row1 >= 0 && row1 < matrix.GetLength(0) &&
                   col1 >= 0 && col1 < matrix.GetLength(1) &&
                   row2 >= 0 && row2 < matrix.GetLength(0) &&
                   col2 >= 0 && col2 < matrix.GetLength(1))
                {

                    string value1 = matrix[row1, col1];
                    string value2 = matrix[row2, col2];
                    matrix[row1, col1] = value2;
                    matrix[row2, col2] = value1;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }

                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}