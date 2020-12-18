using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }         
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int  col = 0;  col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col]+ " ");
                        }

                        Console.WriteLine();
                    }

                    break;
                }

                string[] commandArray = input.Split();
                string command = commandArray[0];
                int rowInCommand = int.Parse(commandArray[1]);
                int colInCommand = int.Parse(commandArray[2]);
                int valueInCommand = int.Parse(commandArray[3]);
                if (rowInCommand < 0 || rowInCommand >= matrix.GetLength(0) || colInCommand < 0 || colInCommand >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else
                {
                    if (command == "Add")
                    {
                        matrix[rowInCommand, colInCommand] += valueInCommand;
                    }

                    else if (command == "Subtract")
                    {
                        matrix[rowInCommand, colInCommand] -= valueInCommand;
                    }
                }
            }
        }
    }
}
