using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public static class Gui
    {
        public static void PrintBoard(string board)
        {
            CalcMaximumSize();
            int board_counter = 0;
            for (int i = 0; i < Globals._boardSize; i++)
            {
                PrintUpperBorder();
                PrintEmptyRow();
                PrintNumbersRow(board, ref board_counter);
                PrintEmptyRow();
            }
            PrintUpperBorder();
            Console.WriteLine();


        }
        public static void PrintNumbersRow(string board, ref int board_counter)
        {
            for (int k = 0; k <= Globals._boardSize * 6; k++)
            {
                if (k % 6 == 0)
                    Console.Write("|");
                else if ((k + 3) % 6 == 0)
                {
                    Console.Write((int)(board[board_counter] - 48));
                    for (int j = 0; j < Globals._biggestNumberSize - (int)(board[board_counter] - 48).ToString().Length; j++)
                        Console.Write(" ");
                    board_counter++;
                }
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void PrintUpperBorder()
        {
            for (int k = 0; k <= Globals._boardSize * 6; k++)
            {
                if ((k + 3) % 6 == 0)
                    for (int i = 0; i < Globals._biggestNumberSize; i++)
                        Console.Write("-");
                else
                    Console.Write("-");
            }
            Console.WriteLine();
        }
        public static void PrintEmptyRow()
        {
            for (int k = 0; k <= Globals._boardSize * 6; k++)
            {
                if (k % 6 == 0)
                    Console.Write("|");
                else if ((k + 3) % 6 == 0)
                    for (int i = 0; i < Globals._biggestNumberSize; i++)
                        Console.Write(" ");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void CalcMaximumSize()
        {
            Globals._biggestNumberSize = Globals._boardSize.ToString().Length;
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
