using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] board = new char[rows, cols];
            for (int row = 0; row < rows; row++) // read the board
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = currentRow[col];
                }
            }

            int numberRemovedKnights = 0;
            while (true) // check the board for knight with maxNumber attack knights
            {
                int maxNumberAttackKnights = int.MinValue;
                int rowMax = int.MinValue;
                int colMax = int.MinValue;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int numberAttackKnights = 0;
                        if (board[row, col] == 'K')
                        {
                            numberAttackKnights = MethodToCheckInFrontOfTheKnight(cols, board, row, col, numberAttackKnights);
                            numberAttackKnights = MethodToCheckBehindTheKnight(rows, cols, board, row, col, numberAttackKnights);
                            numberAttackKnights = MethodToCheckOnLeftTheKnight(rows, board, row, col, numberAttackKnights);
                            numberAttackKnights = MethodToCheckOnRightTheKnight(rows, cols, board, row, col, numberAttackKnights);
                        }

                        if (numberAttackKnights > maxNumberAttackKnights)
                        {
                            maxNumberAttackKnights = numberAttackKnights;
                            rowMax = row;
                            colMax = col;
                        }
                    }
                }

                if (maxNumberAttackKnights > 0)
                {
                    board[rowMax, colMax] = '0';
                    numberRemovedKnights++;
                }

                else if (maxNumberAttackKnights == 0)
                {
                    break;
                }
            }

            Console.WriteLine(numberRemovedKnights);
        }


        private static int MethodToCheckOnRightTheKnight(int rows, int cols, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 1 < rows && col + 2 < cols)
            {
                if (board[row + 1, col + 2] == 'K') // on right 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 1 >= 0 && col + 2 < cols)
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

        private static int MethodToCheckOnLeftTheKnight(int rows, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 1 < rows && col - 2 >= 0)
            {
                if (board[row + 1, col - 2] == 'K') // on left 
                {
                    numberAttackKnights++;
                }
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

        private static int MethodToCheckBehindTheKnight(int rows, int cols, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row + 2 < rows && col + 1 < cols)
            {
                if (board[row + 2, col + 1] == 'K') // behind
                {
                    numberAttackKnights++;
                }
            }

            if (row + 2 < rows && col - 1 >= 0)
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }

        private static int MethodToCheckInFrontOfTheKnight(int cols, char[,] board, int row, int col, int numberAttackKnights)
        {
            if (row - 2 >= 0 && col + 1 < cols)
            {
                if (board[row - 2, col + 1] == 'K') // in front of
                {
                    numberAttackKnights++;
                }
            }

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    numberAttackKnights++;
                }
            }

            return numberAttackKnights;
        }
    }
}

