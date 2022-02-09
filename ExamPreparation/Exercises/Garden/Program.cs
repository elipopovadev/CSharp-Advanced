using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            var matrix = new int[rows, cols];

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] plantCoordinates = command.Split().Select(int.Parse).ToArray();
                int currentRow = plantCoordinates[0];
                int currentCol = plantCoordinates[1];
                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols)
                {
                    for (int i = 0; i < rows; i++) // bloom the flowers on currentCol
                    {
                        if (i == currentRow)
                        {
                            matrix[i, currentCol] = 1;
                        }

                        else if (matrix[i, currentCol] == 0)
                        {
                            matrix[i, currentCol] = 1;
                        }

                        else
                        {
                            matrix[i, currentCol]++;
                        }
                    }

                    for (int k = 0; k < cols; k++) // bloom the flowers on currentRow
                    {
                        if (k == currentCol)
                        {
                            matrix[k, currentCol] = 1;
                        }

                        else if (matrix[currentRow, k] == 0)
                        {
                            matrix[currentRow, k] = 1;
                        }

                        else
                        {
                            matrix[currentRow, k]++;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
