using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];
            for (int row = 0; row < rows; row++) // read the matrix
            {
                double[] currentRow = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArray[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++) // start analyzing the matrix
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    MultiplyEachElementInBothArrays(jaggedArray, row);
                }

                else
                {
                    DivideEachElementInBothArrays(jaggedArray, row);
                }
            }

            while (true) // check for valid commands
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    foreach (double[] currentRow in jaggedArray)
                    {
                        Console.WriteLine(string.Join(" ", currentRow));
                    }

                    break;
                }

                string[] commandArray = command.Split().ToArray();
                int row = int.Parse(commandArray[1]);
                int col = int.Parse(commandArray[2]);
                int value = int.Parse(commandArray[3]);
                if (commandArray[0] == "Add" && row >= 0 && row <= rows - 1 && col >= 0 && col <= jaggedArray[row].Length - 1)
                {
                    jaggedArray[row][col] += value;
                }

                else if(commandArray[0] == "Subtract" && row >= 0 && row <= rows - 1 && col >= 0 && col <= jaggedArray[row].Length - 1)
                {
                    jaggedArray[row][col] -= value;
                }
            }
        }


        private static void DivideEachElementInBothArrays(double[][] jaggedArray, int row)
        {
            for (int i = 0; i < jaggedArray[row].Length; i++)
            {
                jaggedArray[row][i] = jaggedArray[row][i] / 2;
            }

            for (int i = 0; i < jaggedArray[row + 1].Length; i++)
            {
                jaggedArray[row + 1][i] = jaggedArray[row + 1][i] / 2;
            }
        }

        private static void MultiplyEachElementInBothArrays(double[][] jaggedArray, int row)
        {
            for (int i = 0; i < jaggedArray[row].Length; i++)
            {
                jaggedArray[row][i] = jaggedArray[row][i] * 2;
            }

            for (int j = 0; j < jaggedArray[row + 1].Length; j++)
            {
                jaggedArray[row + 1][j] = jaggedArray[row + 1][j] * 2;
            }
        }
    }
}
