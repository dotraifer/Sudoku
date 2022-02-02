using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
   public static  class SolvingTactics
    {
        public static bool LogicalSolveing(Board board)
        {
            bool has_changed = false;
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    if (board.Cells[i, j].Value == 0)
                    {
                        has_changed = FindOnlyPossibility(board, i, j);
                    }
                }
            }
            return has_changed;
        }
        public static bool FindOnlyPossibility(Board board, int row, int col)
        {
            board.Cells[row, col].PossibleNumbers.Clear();
            bool has_changed = false;
            for (int gussed_number = 1; gussed_number <= Globals.BoardSize; gussed_number++)
            {
                if (BoardUtils.IsValid(board, row, col, gussed_number) && DoesOnlyPossible(board, row, col, gussed_number))
                {
                    board.Cells[row, col].Value = gussed_number;
                    has_changed = true;
                    break;
                }
                else if (BoardUtils.IsValid(board, row, col, gussed_number))
                {
                    board.Cells[row, col].PossibleNumbers.Add(gussed_number);
                }
                else
                    board.Cells[row, col].PossibleNumbers.Remove(gussed_number);
            }
            return has_changed;
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
