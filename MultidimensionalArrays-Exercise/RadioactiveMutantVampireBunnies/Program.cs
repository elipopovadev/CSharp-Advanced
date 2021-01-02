using System;
using System.Linq;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnies
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            var matrix = new char[rows, cols];
            int rowStart = 0;
            int colStart = 0;
            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == 'P')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            string commandLine = Console.ReadLine();
            foreach (var command in commandLine)
            {
                int currentRow = rowStart;
                int currentCol = colStart;
                switch (command)
                {
                    case 'U':
                        currentRow--;
                        break;
                    case 'D':
                        currentRow++;
                        break;
                    case 'L':
                        currentCol--;
                        break;
                    case 'R':
                        currentCol++;
                        break;
                    default:
                        break;
                }

                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols) // the player is in the lair
                {
                    if (matrix[currentRow, currentCol] != 'B') // The player doesn't reach bunny
                    {
                        matrix[rowStart, colStart] = '.';
                        matrix[currentRow, currentCol] = 'P';
                        var queueWithBunnies = new Queue<List<int>>();
                        FindWhereAreTheBunnies(rows, cols, matrix, queueWithBunnies);
                        BunniesMultiply(rows, cols, matrix, queueWithBunnies);
                        if (matrix[currentRow, currentCol] != 'B') // after the multiply bunny don't reach the player
                        {
                            rowStart = currentRow;
                            colStart = currentCol;
                            continue;
                        }

                        else if (matrix[currentRow, currentCol] == 'B') // after the multiply bunny reach the player
                        {
                            PrintTheMatrix(rows, cols, matrix);
                            Console.WriteLine($"dead: {currentRow} {currentCol}");
                            return;
                        }
                    }

                    else if (matrix[currentRow, currentCol] == 'B') // The player reaches bunny
                    {
                        var queueWithBunnies = new Queue<List<int>>();
                        FindWhereAreTheBunnies(rows, cols, matrix, queueWithBunnies);
                        BunniesMultiply(rows, cols, matrix, queueWithBunnies);
                        PrintTheMatrix(rows, cols, matrix);
                        Console.WriteLine($"dead: {currentRow} {currentCol}");
                        return;
                    }
                }

                else // The player escapes from the lair     
                {
                    matrix[rowStart, colStart] = '.';
                    var queueWithBunnies = new Queue<List<int>>();
                    FindWhereAreTheBunnies(rows, cols, matrix, queueWithBunnies);
                    BunniesMultiply(rows, cols, matrix, queueWithBunnies);
                    PrintTheMatrix(rows, cols, matrix);
                    Console.WriteLine($"won: {rowStart} {colStart}");
                    return;
                }
            }
        }


        private static void BunniesMultiply(int rows, int cols, char[,] matrix, Queue<List<int>> queueWithBunnies)
        {
            while (queueWithBunnies.Count > 0)
            {
                var bunniesCoordinates = queueWithBunnies.Dequeue();
                int rowBunnies = bunniesCoordinates[0];
                int colBunnies = bunniesCoordinates[1];
                if (rowBunnies - 1 >= 0)
                {
                    matrix[rowBunnies - 1, colBunnies] = 'B';
                }

                if (rowBunnies + 1 < rows)
                {
                    matrix[rowBunnies + 1, colBunnies] = 'B';
                }

                if (colBunnies - 1 >= 0)
                {
                    matrix[rowBunnies, colBunnies - 1] = 'B';
                }

                if (colBunnies + 1 < cols)
                {
                    matrix[rowBunnies, colBunnies + 1] = 'B';
                }
            }
        }

        private static void FindWhereAreTheBunnies(int rows, int cols, char[,] matrix, Queue<List<int>> queueWithBunnies)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        queueWithBunnies.Enqueue(new List<int> { row, col });
                    }
                }
            }
        }

        private static void PrintTheMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}