using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] juggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                juggedArray[row] = currentRow;
            }
            
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    for (int row = 0; row < juggedArray.Length; row++)
                    {
                        for (int  col = 0;  col < juggedArray[row].Length; col++)
                        {
                            Console.Write(juggedArray[row][col] + " ");
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
                if (rowInCommand < 0 || rowInCommand >= juggedArray.Length || colInCommand < 0 || colInCommand >= juggedArray[rowInCommand].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else
                {
                    if (command == "Add")
                    {
                        juggedArray[rowInCommand] [colInCommand] += valueInCommand;
                    }

                    else if (command == "Subtract")
                    {
                        juggedArray[rowInCommand] [colInCommand] -= valueInCommand;
                    }
                }
            }
        }
    }
}
