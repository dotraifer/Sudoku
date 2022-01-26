using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public static class Solver
    {
        public static string Solve(string board_string)
        {
            if (board_string == null)
                return null;
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
