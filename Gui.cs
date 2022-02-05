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
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                if (i % Globals.SmallBoxSize == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                PrintUpperBorder();
                Console.ForegroundColor = ConsoleColor.White;
                PrintEmptyRow();
                PrintNumbersRow(board, ref board_counter);
                PrintEmptyRow();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            PrintUpperBorder();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();


        }
        public static void PrintNumbersRow(string board, ref int board_counter)
        {
            for (int k = 0; k <= Globals.BoardSize * 6; k++)
            {
                if (k % 6 == 0)
                {
                    if ((k % (Globals.SmallBoxSize * 6) == 0))
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if ((k + 3) % 6 == 0)
                {
                    Console.Write((int)(board[board_counter] - 48));
                    for (int j = 0; j < Globals.BiggestNumberSize - (int)(board[board_counter] - 48).ToString().Length; j++)
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
            for (int k = 0; k <= Globals.BoardSize * 6; k++)
            {
                if ((k + 3) % 6 == 0)
                    for (int i = 0; i < Globals.BiggestNumberSize; i++)
                        Console.Write("-");
                else
                    Console.Write("-");
            }
            Console.WriteLine();
        }
        public static void PrintEmptyRow()
        {
            for (int k = 0; k <= Globals.BoardSize * 6; k++)
            {
                if (k % 6 == 0)
                {
                    if (k % (6 * Globals.SmallBoxSize) == 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if ((k + 3) % 6 == 0)
                    for (int i = 0; i < Globals.BiggestNumberSize; i++)
                        Console.Write(" ");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void CalcMaximumSize()
        {
            Globals.BiggestNumberSize = Globals.BoardSize.ToString().Length;
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
