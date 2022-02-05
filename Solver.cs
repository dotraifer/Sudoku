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
                return game.SolveBoard(game.GetBoard());
            }
            catch (UnpossibleBoardSizeExeption e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidCharException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InsolubleBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("board can't be empty!");
            }
            return null;
        }

 
    }
}
