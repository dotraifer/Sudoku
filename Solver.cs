using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    
    /// <summary>
    /// the static class used for solving a given string
    /// </summary>
    public static class Solver
    {

        /// <summary>
        /// this function solving a given string
        /// </summary>
        /// <param name="board_string">the board as a string</param>
        /// <returns>the solution as a string. if the was a problom witht he board(no solution or illegal)-return null</returns>
        public static string Solve(string board_string)
        {
            // if the board is empty
            if (board_string == null)
                return null;
            try
            {
                // create new game
                Game game = new Game(board_string);
                // solve the string
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
            return null;
        }
    }
}
