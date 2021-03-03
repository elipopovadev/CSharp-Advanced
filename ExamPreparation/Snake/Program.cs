using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int rows = arrayLength;
            int cols = arrayLength;
            int rowStart = 0;
            int colStart = 0;
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == 'S')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            int foodEaten = 0;
            while (foodEaten < 10)
            {
                int currentRow = rowStart;
                int currentCol = colStart;
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }

                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols) // the snake is in the lair
                {
                    if (matrix[currentRow, currentCol] != 'B') // The snake doesn't reach a burrow
                    {
                        if (matrix[currentRow, currentCol] == '*')
                        {
                            foodEaten++;
                        }

                        matrix[rowStart, colStart] = '.';
                        matrix[currentRow, currentCol] = 'S';
                        rowStart = currentRow;
                        colStart = currentCol;
                    }

                    else if (matrix[currentRow, currentCol] == 'B')
                    {
                        matrix[rowStart, colStart] = '.';
                        matrix[currentRow, currentCol] = '.';

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'B' && row != currentRow && col != currentCol)
                                {
                                    rowStart = row;
                                    colStart = col;
                                    matrix[rowStart, colStart] = 'S';
                                    break;
                                }
                            }
                        }
                    }
                }

                else // the snake is out
                {
                    matrix[rowStart, colStart] = '.';
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    PrintTheMatrix(rows, cols, matrix);
                    return;
                }
            }

            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine("Food eaten: 10");
            PrintTheMatrix(rows, cols, matrix);
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

