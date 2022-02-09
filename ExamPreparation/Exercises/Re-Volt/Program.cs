using System;

namespace Re_Volt
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
            int countOfCommands = int.Parse(Console.ReadLine());

            bool thePlayerReachedTheFinish = false;
            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == 'f')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                int currentRow = rowStart;
                int currentCol = colStart;
                string command = Console.ReadLine();
                ThePlayerStepsForward(ref currentRow, ref currentCol, command);

                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols) // the player is in the matrix
                {
                    if (matrix[currentRow, currentCol] == 'B') // bonus
                    {
                        ThePlayerStepsForward(ref currentRow, ref currentCol, command);
                        if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols) // the player is in the matrix after one step
                        {
                            matrix[rowStart, colStart] = '-';
                            matrix[currentRow, currentCol] = 'f';
                            rowStart = currentRow;
                            colStart = currentCol;                           
                        }

                        else  // the player goes out of the matrix after one step forward, he comes in from the other side. 
                        {
                            ThePlayerComesInFromOtherSide(arrayLength, ref currentRow, ref currentCol, command);
                            if (matrix[currentRow, currentCol] == 'F') 
                            {
                                matrix[rowStart, colStart] = '-';
                                matrix[currentRow, currentCol] = 'f';
                                thePlayerReachedTheFinish = true;
                                break;
                            }

                            else if (matrix[currentRow, currentCol] == '-')
                            {
                                matrix[rowStart, colStart] = '-';
                                matrix[currentRow, currentCol] = 'f';
                                rowStart = currentRow;
                                colStart = currentCol;
                            }
                        }
                    }

                    else if (matrix[currentRow, currentCol] == 'T') // trap
                    {
                        ThePlayerStepsBackward(ref currentRow, ref currentCol, command);
                        rowStart = currentRow;
                        colStart = currentCol;
                        matrix[rowStart, colStart] = 'f';
                    }

                    else if (matrix[currentRow, currentCol] == 'F') // finish
                    {
                        matrix[rowStart, colStart] = '-';
                        matrix[currentRow, currentCol] = 'f';
                        thePlayerReachedTheFinish = true;
                        break;
                    }

                    else if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[rowStart, colStart] = '-';
                        matrix[currentRow, currentCol] = 'f';
                        rowStart = currentRow;
                        colStart = currentCol;
                    }
                }

                else  // the player goes out of the matrix after command, he comes in from the other side. 
                {
                    ThePlayerComesInFromOtherSide(arrayLength, ref currentRow, ref currentCol, command);
                    if (matrix[currentRow, currentCol] == 'B') // bonus
                    {
                        matrix[rowStart, colStart] = '-';
                        ThePlayerStepsForward(ref currentRow, ref currentCol, command);
                        rowStart = currentRow;
                        colStart = currentCol;
                        matrix[rowStart, colStart] = 'f';
                    }

                    else if (matrix[currentRow, currentCol] == 'T') // trap
                    {
                        ThePlayerStepsBackward(ref currentRow, ref currentCol, command);
                        rowStart = currentRow;
                        colStart = currentCol;
                        matrix[rowStart, colStart] = 'f';
                    }

                    else if (matrix[currentRow, currentCol] == 'F') // finish
                    {
                        matrix[rowStart, colStart] = '-';
                        matrix[currentRow, currentCol] = 'f';
                        thePlayerReachedTheFinish = true;
                        break;
                    }

                    else if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[rowStart, colStart] = '-';
                        matrix[currentRow, currentCol] = 'f';
                        rowStart = currentRow;
                        colStart = currentCol;
                    }
                }
            }

            if (thePlayerReachedTheFinish == true)
            {
                Console.WriteLine("Player won!");
                PrintTheMatrix(rows, cols, matrix);
            }

            else
            {
                Console.WriteLine("Player lost!");
                PrintTheMatrix(rows, cols, matrix);
            }
        }


        private static void ThePlayerStepsBackward(ref int currentRow, ref int currentCol, string command)
        {
            switch (command)
            {
                case "up":
                    currentRow++;
                    break;
                case "down":
                    currentRow--;
                    break;
                case "left":
                    currentCol++;
                    break;
                case "right":
                    currentCol--;
                    break;
            }
        }

        private static void ThePlayerComesInFromOtherSide(int arrayLength, ref int currentRow, ref int currentCol, string command)
        {
            switch (command)
            {
                case "up":
                    currentRow = arrayLength - 1;
                    break;
                case "down":
                    currentRow = 0;
                    break;
                case "left":
                    currentCol = arrayLength - 1;
                    break;
                case "right":
                    currentCol = 0;
                    break;
            }
        }

        private static void ThePlayerStepsForward(ref int currentRow, ref int currentCol, string command)
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
