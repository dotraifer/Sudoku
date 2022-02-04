using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{

    /// <summary>
    /// static cclass that contain all the UI methods
    /// </summary>
    public static class Gui
    {
        static int cellWidth = 6;
        /// <summary>
        /// this function print a given board in pretty way
        /// </summary>
        /// <param name="board">thestring reprosent the board we would like to print</param>
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

        /// <summary>
        /// this function print the row with the numbers in the console
        /// </summary>
        /// <param name="board">the board numbers to pront</param>
        /// <param name="board_counter">the number in the board to start printing from</param>
        public static void PrintNumbersRow(string board, ref int board_counter)
        {
            for (int k = 0; k <= Globals.BoardSize * cellWidth; k++)
            {
                if (k % cellWidth == 0)
                {
                    if ((k % (Globals.SmallBoxSize * cellWidth) == 0))
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if ((k + cellWidth / 2) % cellWidth == 0)
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

        /// <summary>
        /// print upeper border for every row
        /// </summary>
        public static void PrintUpperBorder()
        {
            for (int k = 0; k <= Globals.BoardSize * cellWidth; k++)
            {
                if ((k + cellWidth / 2) % cellWidth == 0)
                    for (int i = 0; i < Globals.BiggestNumberSize; i++)
                        Console.Write("-");
                else
                    Console.Write("-");
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// print an empty row in the board
        /// </summary>
        public static void PrintEmptyRow()
        {
            for (int k = 0; k <= Globals.BoardSize * cellWidth; k++)
            {
                if (k % cellWidth == 0)
                {
                    if (k % (cellWidth * Globals.SmallBoxSize) == 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if ((k + cellWidth / 2) % cellWidth == 0)
                    for (int i = 0; i < Globals.BiggestNumberSize; i++)
                        Console.Write(" ");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// calculate the biggest number possible in the print
        /// </summary>
        public static void CalcMaximumSize()
        {
            Globals.BiggestNumberSize = Globals.BoardSize.ToString().Length;
        }

        /// <summary>
        /// print the user choosing manu
        /// </summary>
        public static void PrintManu()
        {
            Console.WriteLine("\n*Welcome to the sudoku solver*");
            Console.WriteLine("- to enter board throught the console - enter the word console");
            Console.WriteLine("- to enter board throught the file - enter the word file");
            Console.WriteLine("- to exit the sudoku solver - enter the word exit");
        }
    }
}
