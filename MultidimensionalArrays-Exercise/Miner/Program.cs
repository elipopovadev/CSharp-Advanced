using System;
using System.Linq;
namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            string[] commandArray = Console.ReadLine().Split().ToArray();
            char[,] matrix = new char[rows, cols];
            int rowStart = 0;
            int colStart = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] currentLine = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == 's')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            foreach (string command in commandArray)
            {
                int currentRow = rowStart;
                int currentCol = colStart;
                switch (command)
                {
                    case "up":
                        currentRow--;
                        currentCol = colStart;
                        break;
                    case "down":
                        currentRow++;
                        currentCol = colStart;
                        break;
                    case "left":
                        currentRow = rowStart;
                        currentCol--;
                        break;
                    case "right":
                        currentRow = rowStart;
                        currentCol++;
                        break;
                }

                if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols)
                {
                    rowStart = currentRow;
                    colStart = currentCol;
                    switch (matrix[rowStart, colStart])
                    {
                        case 'e':
                            Console.WriteLine($"Game over! ({rowStart}, {colStart})");
                            return;
                        case 'c':
                            matrix[rowStart, colStart] = '*';
                            break;
                    }
                }
            }

            int countCoalsLeft = matrix.Cast<char>().Count(symbol => symbol == 'c');
            Console.WriteLine(countCoalsLeft == 0
                ? $"You collected all coals! ({rowStart}, {colStart})"
                : $"{countCoalsLeft} coals left. ({rowStart}, {colStart})");
        }
    }
}