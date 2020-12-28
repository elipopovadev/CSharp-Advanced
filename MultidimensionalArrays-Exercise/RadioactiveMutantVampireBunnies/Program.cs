using System;
using System.Linq;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];
            ReadTheMatrix(rows, cols, matrix);
            int rowPlayerStart = 0;
            int colPlayerStart = 0;
            bool haveStart = false;
            for (int row = 0; row < rows; row++) // validate the matrix
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != 'P' && matrix[row, col] != '.' && matrix[row, col] != 'B')
                    {
                        return;
                    }

                    if (matrix[row, col] == 'P')
                    {
                        rowPlayerStart = row;
                        colPlayerStart = col;
                        haveStart = true;
                    }

                    else if (haveStart == true && matrix[row, col] == 'P')
                    {
                        return;
                    }
                }
            }

            if (haveStart)
            {
                char startPlayer = matrix[rowPlayerStart, colPlayerStart];
            }

            else
            {
                return;
            }

            char[] commandArray = Console.ReadLine().ToArray();
            int currentRowWithPlayer = 0;
            int currentColWithPlayer = 0;
            bool haveBunnyInTheCurrentCell = false;

            for (int i = 0; i < commandArray.Length; i++)
            {
                string direction = commandArray[i].ToString();
                if (direction == 'U'.ToString())
                {
                    if (rowPlayerStart - 1 >= 0)
                    {
                        currentRowWithPlayer = rowPlayerStart - 1;
                        currentColWithPlayer = colPlayerStart;
                        matrix[rowPlayerStart, colPlayerStart] = '.';
                        if (matrix[currentRowWithPlayer, currentColWithPlayer] == 'B') // the player reached cell with bunny
                        {
                            haveBunnyInTheCurrentCell = true;
                        }
                    }

                    else if (rowPlayerStart - 1 < 0) matrix[rowPlayerStart, colPlayerStart] = '.';
                    var stackWithRowsWhereHaveBunnies = new Stack<int>();
                    var stackWithColsWhereHaveBunnies = new Stack<int>();
                    SaveWhereAreTheBunnies(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    BunniesMultiply(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    if (rowPlayerStart - 1 < 0) break;
                    if (rowPlayerStart - 1 >= 0)
                    {
                        CheckForBunny(matrix, ref rowPlayerStart, ref colPlayerStart, currentRowWithPlayer, currentColWithPlayer, ref haveBunnyInTheCurrentCell);
                    }
                }

                else if (direction == 'D'.ToString())
                {
                    if (rowPlayerStart + 1 < rows)
                    {
                        currentRowWithPlayer = rowPlayerStart + 1;
                        currentColWithPlayer = colPlayerStart;
                        matrix[rowPlayerStart, colPlayerStart] = '.';

                        if (matrix[currentRowWithPlayer, currentColWithPlayer] == 'B') // the player reached cell with bunny
                        {
                            haveBunnyInTheCurrentCell = true;
                        }
                    }

                    else if (rowPlayerStart + 1 >= rows) matrix[rowPlayerStart, colPlayerStart] = '.';
                    var stackWithRowsWhereHaveBunnies = new Stack<int>();
                    var stackWithColsWhereHaveBunnies = new Stack<int>();
                    SaveWhereAreTheBunnies(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    BunniesMultiply(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    if (rowPlayerStart + 1 >= rows) break;
                    if (rowPlayerStart + 1 < rows)
                    {
                        CheckForBunny(matrix, ref rowPlayerStart, ref colPlayerStart, currentRowWithPlayer, currentColWithPlayer, ref haveBunnyInTheCurrentCell);
                    }
                }

                else if (direction == 'L'.ToString())
                {
                    if (colPlayerStart - 1 >= 0)
                    {
                        currentRowWithPlayer = rowPlayerStart;
                        currentColWithPlayer = colPlayerStart - 1;
                        matrix[rowPlayerStart, colPlayerStart] = '.';
                        if (matrix[currentRowWithPlayer, currentColWithPlayer] == 'B') // the player reached cell with bunny
                        {
                            haveBunnyInTheCurrentCell = true;
                        }
                    }

                    else if (colPlayerStart - 1 < 0) matrix[rowPlayerStart, colPlayerStart] = '.';
                    var stackWithRowsWhereHaveBunnies = new Stack<int>();
                    var stackWithColsWhereHaveBunnies = new Stack<int>();
                    SaveWhereAreTheBunnies(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    BunniesMultiply(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    if (colPlayerStart - 1 < 0) break;
                    if (colPlayerStart - 1 >= 0)
                    {
                        CheckForBunny(matrix, ref rowPlayerStart, ref colPlayerStart, currentRowWithPlayer, currentColWithPlayer, ref haveBunnyInTheCurrentCell);
                    }                
                }

                else if (direction == 'R'.ToString())
                {
                    if (colPlayerStart + 1 < cols)
                    {
                        currentRowWithPlayer = rowPlayerStart;
                        currentColWithPlayer = colPlayerStart + 1;
                        matrix[rowPlayerStart, colPlayerStart] = '.';
                        if (matrix[currentRowWithPlayer, currentColWithPlayer] == 'B') // the player reached cell with bunny
                        {
                            haveBunnyInTheCurrentCell = true;
                        }
                    }

                    else if (colPlayerStart + 1 >= cols) matrix[rowPlayerStart, colPlayerStart] = '.';
                    var stackWithRowsWhereHaveBunnies = new Stack<int>();
                    var stackWithColsWhereHaveBunnies = new Stack<int>();
                    SaveWhereAreTheBunnies(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    BunniesMultiply(rows, cols, matrix, stackWithRowsWhereHaveBunnies, stackWithColsWhereHaveBunnies);
                    if(colPlayerStart + 1 >= cols) break;
                    if (colPlayerStart + 1 < cols)
                    {
                        CheckForBunny(matrix, ref rowPlayerStart, ref colPlayerStart, currentRowWithPlayer, currentColWithPlayer, ref haveBunnyInTheCurrentCell);
                    }
                }

                if (haveBunnyInTheCurrentCell)
                {
                    break;
                }
            }

            PrintTheResult(rows, cols, matrix, rowPlayerStart, colPlayerStart, currentRowWithPlayer, currentColWithPlayer, haveBunnyInTheCurrentCell);
        }


        private static void CheckForBunny(char[,] matrix, ref int rowPlayerStart, ref int colPlayerStart, int currentRowWithPlayer, int currentColWithPlayer, ref bool haveBunnyInTheCurrentCell)
        {
            if (matrix[currentRowWithPlayer, currentColWithPlayer] == 'B') // bunny reached the player
            {
                haveBunnyInTheCurrentCell = true;
            }

            else if (matrix[currentRowWithPlayer, currentColWithPlayer] != 'B')
            {
                matrix[currentRowWithPlayer, currentColWithPlayer] = 'P';
                rowPlayerStart = currentRowWithPlayer;
                colPlayerStart = currentColWithPlayer;
            }
        }

        private static void SaveWhereAreTheBunnies(int rows, int cols, char[,] matrix, Stack<int> stackWithRowsWhereHaveBunnies, Stack<int> stackWithColsWhereHaveBunnies)
        {
            for (int row = 0; row < rows; row++)  // find cells where are the bunnies
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        stackWithRowsWhereHaveBunnies.Push(row);
                        stackWithColsWhereHaveBunnies.Push(col);
                    }
                }
            }
        }

        private static void BunniesMultiply(int rows, int cols, char[,] matrix, Stack<int> stackWithRowsWhereHaveBunnies, Stack<int> stackWithColsWhereHaveBunnies)
        {
            while (stackWithRowsWhereHaveBunnies.Count > 0 && stackWithColsWhereHaveBunnies.Count > 0) // bunnies multiply very fast
            {
                int currentRowWithBunny = stackWithRowsWhereHaveBunnies.Pop();
                int currentColWithBunny = stackWithColsWhereHaveBunnies.Pop();
                if (currentRowWithBunny - 1 >= 0) matrix[currentRowWithBunny - 1, currentColWithBunny] = 'B'; // up
                if (currentRowWithBunny + 1 < rows) matrix[currentRowWithBunny + 1, currentColWithBunny] = 'B'; // down
                if (currentColWithBunny - 1 >= 0) matrix[currentRowWithBunny, currentColWithBunny - 1] = 'B'; // left
                if (currentColWithBunny + 1 < cols) matrix[currentRowWithBunny, currentColWithBunny + 1] = 'B'; // right
            }
        }

        private static void PrintTheResult(int rows, int cols, char[,] matrix, int rowPlayerStart, int colPlayerStart, int currentRowWithPlayer, int currentColWithPlayer, bool haveBunnyInTheCurrentCell)
        {
            if (haveBunnyInTheCurrentCell)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();

                }

                Console.WriteLine($"dead: { currentRowWithPlayer} { currentColWithPlayer}");
            }

            else
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();

                }

                Console.WriteLine($"won: {rowPlayerStart} {colPlayerStart}");
            }
        }

        private static void ReadTheMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }
    }
}