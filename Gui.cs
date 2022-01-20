using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public static class Gui
    {
        public static void PrintBoard(string board)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int k = 0; k < Globals._boardSize * 4; k++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    Console.Write(String.Format((int)(board[Globals._boardSize * i + j] - 48) + " " + "| "));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
