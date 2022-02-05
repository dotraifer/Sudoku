using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public static class SolvingTactics
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
                        if (!has_changed)
                            has_changed = FindOnlyPossibility(board, i, j);
                        else
                            FindOnlyPossibility(board, i, j);
                        FindNakedGroup(board, i, j);
                    }
                }
            }
            return has_changed;
        }

        public static bool FindOnlyPossibility(Board board, int row, int col)
        {
            bool has_changed = false;
            for (int gussed_number = 1; gussed_number <= Globals.BoardSize; gussed_number++)
            {
                if (Board.IsValid(board, row, col, gussed_number) && DoesOnlyPossible(board, row, col, gussed_number))
                {
                    board.Cells[row, col].Value = gussed_number;
                    DeleteFromRow(board, row, new List<int>(gussed_number));
                    DeleteFromCol(board, col, new List<int>(gussed_number));
                    DeleteFromBox(board, row, col, new List<int>(gussed_number));
                    has_changed = true;
                    break;
                }
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
            // get the coordinates of the first square in the small box
            int firstBoxRow = row - row % Globals.SmallBoxSize;
            int firstBoxColumn = col - col % Globals.SmallBoxSize;
            if (board.Cells[row, col].PossibleNumbers.Count == 1)
            {
                return true;
            }
            // if each row, col or small box, check if there is other box that the number can be applied to
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                // check row
                if (board.Cells[i, col].Value == 0 && i != row && rowFlag)
                    rowFlag = !Board.IsValid(board, i, col, gussed_number);
                // check col
                if (board.Cells[row, i].Value == 0 && i != col && colFlg)
                    colFlg = !Board.IsValid(board, row, i, gussed_number);
            }
            // check small box
            for (int i = firstBoxRow; i < firstBoxRow + Globals.SmallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + Globals.SmallBoxSize; j++)
                {
                    if (board.Cells[i, j].Value == 0 && !(i == row && j == col))
                    {
                        smallBoxFlag = !Board.IsValid(board, i, j, gussed_number);
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

        public static void FindNakedGroup(Board board, int row, int col)
        {
            int rowCounter = 0;
            int colCounter = 0;
            int boxCounter = 0;
            int firstBoxRow = row - row % Globals.SmallBoxSize;
            int firstBoxColumn = col - col % Globals.SmallBoxSize;
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                if (board.Cells[i, col].Value == 0 && i != row && IsListEqueal(board.Cells[row, col].PossibleNumbers, board.Cells[i, col].PossibleNumbers))
                    rowCounter++;
                // check col
                if (board.Cells[row, i].Value == 0 && i != col && IsListEqueal(board.Cells[row, col].PossibleNumbers, board.Cells[row, i].PossibleNumbers))
                    colCounter++;
            }
            for (int i = firstBoxRow; i < firstBoxRow + Globals.SmallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + Globals.SmallBoxSize; j++)
                {
                    if (board.Cells[i, j].Value == 0 && !(i == row && j == col) && IsListEqueal(board.Cells[row, col].PossibleNumbers, board.Cells[i, j].PossibleNumbers))
                    {
                        boxCounter++;
                    }
                }
            }
            if (rowCounter == board.Cells[row, col].PossibleNumbers.Count)
                DeleteFromRow(board, row, board.Cells[row, col].PossibleNumbers);
            if (rowCounter == board.Cells[row, col].PossibleNumbers.Count)
                DeleteFromCol(board, col, board.Cells[row, col].PossibleNumbers);
            if (rowCounter == board.Cells[row, col].PossibleNumbers.Count)
                DeleteFromBox(board, row, col, board.Cells[row, col].PossibleNumbers);
        }


        public static void DeleteFromRow(Board board, int row, List<int> ToDelete)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                if (!IsListEqueal(ToDelete, board.Cells[row, i].PossibleNumbers))
                    foreach (int delete in ToDelete)
                        board.Cells[row, i].PossibleNumbers.Remove(delete);
            }
        }

        public static void DeleteFromCol(Board board, int col, List<int> ToDelete)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                if (!IsListEqueal(ToDelete, board.Cells[i, col].PossibleNumbers))
                    foreach (int delete in ToDelete)
                        board.Cells[i, col].PossibleNumbers.Remove(delete);
            }
        }

        public static void DeleteFromBox(Board board, int row, int col, List<int> ToDelete)
        {
            for (int i = 0; i < Globals.SmallBoxSize; i++)
            {
                for (int j = 0; j < Globals.SmallBoxSize; j++)
                {
                    if (!IsListEqueal(ToDelete, board.Cells[row, col].PossibleNumbers))
                        foreach (int delete in ToDelete)
                            board.Cells[row, col].PossibleNumbers.Remove(delete);
                }
            }
        }

        public static bool IsListEqueal(List<int> firstList, List<int> secondList)
        {
            if (firstList.Count == secondList.Count && firstList.Count != 0)
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (firstList[i] != secondList[i])
                        return false;
                }
            }
            else
                return false;
            return true;
        }
    }
}
