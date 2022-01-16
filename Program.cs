using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("~enter a string that would represent the _board you want to solve~");
                String board_string = Console.ReadLine();
                int [,] result_board = Solve(board_string);
                Gui.PrintBoard(result_board);
            }
        }
        public static int[,] Solve(string board_string)
        {
            try
            {
                Game game = new Game(board_string);
                return game.SolveBoard();
            }
            catch(UnpossibleBoardSizeExeption e)
            {
                Console.WriteLine(e);
            }
            catch(InvalidCharException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
