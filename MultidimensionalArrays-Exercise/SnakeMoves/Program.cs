using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string snake = Console.ReadLine();
            var queueSnake = new Queue<char>(snake.ToArray());         
            char[,] matrix = new char[rows, cols]; // create char matrix with rows and cols          

            for (int row = 0; row < rows; row++) // fill in the matrix
            {
                for (int col = 0; col < cols; col++)
                {                  
                    if (row % 2 == 0)
                    {
                        char currentSymbol = RollTheSnake(queueSnake);
                        matrix[row, col] = currentSymbol;
                    }

                    else if (row % 2 != 0)
                    {
                        for (int j = cols - 1; j >= 0; j--)
                        {
                            char currentSymbol = RollTheSnake(queueSnake);
                            matrix[row, j] = currentSymbol;
                        }

                        break;
                    }
                }               
            }

            PrintMatrix(matrix);
        }


        private static char RollTheSnake(Queue<char> queueSnake)
        {
            char currentSymbol = queueSnake.Dequeue();
            queueSnake.Enqueue(currentSymbol);
            return currentSymbol;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
