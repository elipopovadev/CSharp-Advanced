using System;

namespace Selling
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

            int sumMoney = 0;
            while (sumMoney < 50)
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

                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols) // I'am in the bakery
                {
                    if (matrix[currentRow, currentCol] != 'O') // I don't reach a pilar
                    {
                        if (char.IsDigit(matrix[currentRow, currentCol]))
                        {
                            int currentDigit = int.Parse(matrix[currentRow,currentCol].ToString());
                            sumMoney += currentDigit;
                        }

                        matrix[rowStart, colStart] = '-';
                        matrix[currentRow, currentCol] = 'S';
                        rowStart = currentRow;
                        colStart = currentCol;
                    }

                    else if (matrix[currentRow, currentCol] == 'O')
                    {
                        matrix[rowStart, colStart] = '-';
                        matrix[currentRow, currentCol] = '-';

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'O' && row != currentRow && col != currentCol)
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

                else // I'am out 
                {
                    matrix[rowStart, colStart] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {sumMoney}");                  
                    PrintTheMatrix(rows, cols, matrix);
                    return;
                }

                if(sumMoney >= 50)
                {
                    matrix[rowStart, colStart] = '-';
                    matrix[currentRow, currentCol] = 'S';
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {sumMoney}");
                    PrintTheMatrix(rows, cols, matrix);
                    return;
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
