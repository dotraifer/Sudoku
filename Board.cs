using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class Board
    {
        private Cell[,] mCells;
        public Cell[,] Cells
        {
            get { return mCells; }
            set { mCells = value; }
        }
        public Board(Cell[,] cells)
        {
            this.Cells = cells;
        }
        public bool SolveBoard(Board board)
        {
            bool has_changed = true;
            while (has_changed)
            {
                has_changed = LogicalSolveing(board);
            }
            return BackTracking(board);
        }
        public bool BackTracking(Board board)
        {
            Cell cellChecked = FindLeastOptionsCell(board.Cells);
            if(cellChecked == null)
            {
                if(Solver.IsBoardSolved(board))
                {
                    Cells = board.ArrayCopy();
                    return true;
                }
                return false;
            }
            if (cellChecked.Value == 0)
            {
                foreach (int possibleNum in cellChecked.PossibleNumbers)
                {
                    if (Solver.IsValid(board, cellChecked.XLocation, cellChecked.YLocation, possibleNum))
                    {
                        Board newBoard = new Board(board.ArrayCopy());
                        //Board newBoard = new 
                        newBoard.Cells[cellChecked.XLocation, cellChecked.YLocation].Value = possibleNum;
                        if (SolveBoard(newBoard))
                        {
                            if(!Solver.IsBoardSolved(this))
                                Cells = newBoard.ArrayCopy();
                            return true;
                        }
                                
                    }                  
                }
                return false;
            }
            return true;
        }
        public Cell[,] ArrayCopy()
        {
            Cell[,] result = new Cell[Cells.GetLength(0), Cells.GetLength(1)]; //Create a result array that is the same length as the input array
            for (int x = 0; x < Cells.GetLength(0); ++x) //Iterate through the horizontal rows of the two dimensional array
            {
                for (int y = 0; y < Cells.GetLength(1); ++y) //Iterate throught the vertical rows, to add more dimensions add another for loop for z
                {
                    result[x, y] = new Cell(Cells[x,y].Value, Cells[x, y].XLocation, Cells[x, y].YLocation); //Change result x,y to input x,y
                }
            }
            return result;
        }
        public bool LogicalSolveing(Board board)
        {
            bool has_changed = false;
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    if(board.Cells[i, j].Value == 0)
                    {
                        has_changed = FindOnlyPossibility(board, i , j);
                    }
                }
            }
            return has_changed;
        }
        public bool FindOnlyPossibility(Board board, int row, int col)
        {
            board.Cells[row, col].PossibleNumbers.Clear();
            bool has_changed = false;
            for (int gussed_number = 1; gussed_number <= Globals.BoardSize; gussed_number++)
            {
                if (Solver.IsValid(board, row, col, gussed_number) && DoesOnlyPossible(board, row, col, gussed_number))
                {
                    board.Cells[row, col].Value = gussed_number;
                    has_changed = true;
                    break;
                }
                else if(Solver.IsValid(board, row, col, gussed_number))
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
        public bool DoesOnlyPossible(Board board ,int row, int col, int gussed_number)
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
                    rowFlag = !Solver.IsValid(board, i, col, gussed_number);
                // check col
                if (board.Cells[row, i].Value == 0 && i != col && colFlg)
                    colFlg = !Solver.IsValid(board, row, i, gussed_number);
            }
            // check small box
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board.Cells[i, j].Value == 0 && !(i == row && j == col))
                    {
                        smallBoxFlag = !Solver.IsValid(board, i, j, gussed_number);
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
        public Cell FindLeastOptionsCell(Cell[,] cells)
        {
            Cell minCell = null;
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    if (cells[i, j].Value == 0)
                    {
                        if (minCell == null)
                            minCell = cells[i, j];
                        if (cells[i, j].PossibleNumbers.Count < minCell.PossibleNumbers.Count )
                            minCell = cells[i, j];
                    }
                }
            }
            return minCell;
        }
        public void PrintMatrix(Board board)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    Console.Write(board.Cells[i, j].Value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
