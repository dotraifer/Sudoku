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
        public static void PrintManu()
        {
            Console.WriteLine("\n*Welcome to the sudoku solver*");
            Console.WriteLine("- to enter board throught the console - enter the word console");
            Console.WriteLine("- to enter board throught the file - enter the word file");
            Console.WriteLine("- to exit the sudoku solver - enter the word exit");
        }
    }
}
