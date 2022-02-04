using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{

   /// <summary>
   /// static class that contain static methods for our board solving tactics
   /// </summary>
   public static  class SolvingTactics
    {

        /// <summary>
        /// static void function that solve in logical way a given board as must as she can
        /// </summary>
        /// <remarks>naked singles and hidden singles implement</remarks>
        /// <see cref="http://hodoku.sourceforge.net/en/tech_singles.php"/>
        /// <param name="board">the board to solve</param>
        public static void LogicalSolveing(Board board)
        {
            // for every cell
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    // if 0, find possibilities
                    if (board.Cells[i, j].Value == 0)
                    {
                         FindPossibilities(board, i,j);
                    }
                }
            }
        }

        /// <summary>
        /// static void function that finds the possibilities for a given empty cell, if it has only one possibility it put it in there
        /// and update the hasChanged to True
        /// </summary>
        /// <param name="board">the board we check on</param>
        /// <param name="row">the row coordinate of the cell</param>
        /// <param name="col">the column spot of the cell</param>
        public static void FindPossibilities(Board board, int row, int col)
        {
            // clear the list
            board.Cells[row, col].PossibleNumbers.Clear();
            // if we found only possubility
            for (int gussed_number = 1; gussed_number <= Globals.BoardSize; gussed_number++)
            {
                // if valid and only number possible
                if (BoardUtils.IsValid(board, row, col, gussed_number) && DoesOnlyPossible(board, row, col, gussed_number))
                {
                    board.Cells[row, col].Value = gussed_number;
                    break;
                }
                // else if just valid
                else if (BoardUtils.IsValid(board, row, col, gussed_number))
                {
                    board.Cells[row, col].PossibleNumbers.Add(gussed_number);
                }
            }
        }

        /// <summary>
        /// this function check by looking on the row, col and small bax of the place, if the gueesed number is the only possible number for the square we check on. 
        /// </summary>
        /// <param name="board"> the board state we want to check on</param>
        /// <param name="row"> the row of the place we want to check if there are only one possibility</param>
        /// <param name="col"> the col of the place we want to check if there are only one possibility</param>
        /// <param name="gussed_number">the number we check if he is the only one possible</param>
        /// <returns>True if the gueesed number is the only suitable for the row and col, False otherwise</returns>
        public static bool DoesOnlyPossible(Board board, int row, int col, int gussed_number)
        {
            bool breakLoops = false;
            // flag that say if the number is the only possibility according to the row
            bool rowFlag = true;
            // flag that say if the number is the only possibility according to the col
            bool colFlg = true;
            // flag that say if the number is the only possibility according to the small Box
            bool smallBoxFlag = true;
            int smallBoxSize = (int)Math.Sqrt(Globals.BoardSize);
            // get the coordinates of the first square in the small box
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            // if each row, col or small box, check if there is other box that the number can be applied to
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                // check row
                if (board.Cells[i, col].Value == 0 && i != row && rowFlag)
                    rowFlag = !BoardUtils.IsValid(board, i, col, gussed_number);
                // check col
                if (board.Cells[row, i].Value == 0 && i != col && colFlg)
                    colFlg = !BoardUtils.IsValid(board, row, i, gussed_number);
            }
            // check small box
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board.Cells[i, j].Value == 0 && !(i == row && j == col))
                    {
                        smallBoxFlag = !BoardUtils.IsValid(board, i, j, gussed_number);
                        if (!smallBoxFlag)
                        {
                            breakLoops = true;
                            break;
                        }

                    }
                }
                if (breakLoops)
                    break;
            }
            // will return true if in one of those the the gueesed number in row, col is the only possibility
            return rowFlag || colFlg || smallBoxFlag;

        }
    }
}
