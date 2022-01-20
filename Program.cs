using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("~enter a string that would represent the _board you want to solve~");
                string board_string = Console.ReadLine();
                string result_board = Solve(board_string);
                Console.WriteLine(result_board);
                Gui.PrintBoard(board_string);
                if (result_board != null)
                    Gui.PrintBoard(result_board);
            }
        }
        public static string Solve(string board_string)
        {
            try
            {
                Game game = new Game(board_string);
                return game.SolveBoard();
            }
            catch (UnpossibleBoardSizeExeption e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidCharException e)
            {
                Console.WriteLine(e);
            }
            catch (InsolubleBoardException e)
            {
                Console.WriteLine(e);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("board can't be empty!");
            }
            return null;
        }
    }
}
