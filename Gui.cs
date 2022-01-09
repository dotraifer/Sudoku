using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public static class Gui
    {
        public static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
