using System;

namespace Bee
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
                    if (matrix[row, col] == 'B')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            int countFlowers = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int currentRow = rowStart;
                int currentCol = colStart;
                SwitchCommand(command, ref currentRow, ref currentCol);

                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols) // the bee is in the matrix
                {
                    if (matrix[currentRow, currentCol] == 'f' || matrix[currentRow, currentCol] == '.')
                    {
                        countFlowers = CountFlowers(matrix, countFlowers, currentRow, currentCol);
                        matrix[rowStart, colStart] = '.';
                        matrix[currentRow, currentCol] = 'B';
                        rowStart = currentRow;
                        colStart = currentCol;
                    }

                    else if (matrix[currentRow, currentCol] == 'O')  
                    {
                        matrix[rowStart, colStart] = '.';
                        matrix[currentRow, currentCol] = '.';
                        SwitchCommand(command, ref currentRow, ref currentCol); // the bee has one command bonus

                        countFlowers = CountFlowers(matrix, countFlowers, currentRow, currentCol);
                        matrix[currentRow, currentCol] = 'B';
                        rowStart = currentRow;
                        colStart = currentCol;
                    }
                }

                else // the bee is out after command
                {
                    matrix[rowStart, colStart] = '.';
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }

            PrintFinalResult(rowStart, colStart, matrix, countFlowers);
            PrintTheMatrix(rows, cols, matrix);
        }

        private static void SwitchCommand(string command, ref int currentRow, ref int currentCol)
        {
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
        }

        private static int CountFlowers(char[,] matrix, int countFlowers, int currentRow, int currentCol)
        {
            if (matrix[currentRow, currentCol] == 'f')
            {
                countFlowers++;
            }

            return countFlowers;
        }

        private static void PrintFinalResult(int rowStart, int colStart, char[,] matrix, int countFlowers)
        {
            if (countFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - countFlowers} flowers more");
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