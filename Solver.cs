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

        public static bool IsBoardValid(Board board)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    if (board.Cells[i, j].Value != 0 && !IsValid(board, i, j, board.Cells[i, j].Value))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// this function will check if to put number in the row and col coordinate is valid
        /// </summary>
        /// <param name="board">the board state we check on</param>
        /// <param name="row"> the row we check</param>
        /// <param name="col"> the col we check</param>
        /// <param name="number">the number we check</param>
        /// <returns>True if valid False otherwise</returns>
        public static  bool IsValid(Board board, int row, int col, int number)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                //check row  
                if (board.Cells[i, col].Value != 0 && i != row && board.Cells[i, col].Value == number)
                    return false;
                //check column  
                if (board.Cells[row, i].Value != 0 && i != col && board.Cells[row, i].Value == number)
                    return false;
                //check smaller box block  
            }
            if (!IsSmallBoxValid(board, row, col, number))
                return false;
            return true;
        }

        /// <summary>
        /// this function check if the number is already in the small box, or it is possible to put him in the rowand col coorinate
        /// </summary>
        /// <param name="board">the board state we check on</param>
        /// <param name="row"> the row we check</param>
        /// <param name="col"> the col we check</param>
        /// <param name="number">the number we check</param>
        /// <returns>True if it valid to put the number in the small box, false otherwise</returns>
        public static bool IsSmallBoxValid(Board board, int row, int col, int number)
        {
            // 010040050407000602820600074000010500500000003004050000960003045305000801070020030
            // 000260701680070090190004500820100040004602900050003028009300074040050036703018000
            int smallBoxSize = (int)Math.Sqrt(Globals.BoardSize);
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board.Cells[i, j].Value == number && !(i == row && j == col))
                        return false;
                }
            }
            return true;

        }
        public static bool IsBoardSolved(Board board)
        {
            for (int i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < board.Cells.GetLength(1); j++)
                {
                    if (board.Cells[i, j].Value == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
