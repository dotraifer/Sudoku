using System;
using System.Collections.Generic;

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
            FindPossibaleNumbersValues(board);
            bool has_changed = true;
            while (has_changed)
            {
                has_changed = SolvingTactics.LogicalSolveing(board);
            }
            return BackTracking(board);
        }
        public bool BackTracking(Board board)
        {
            Cell cellChecked = FindLeastOptionsCell(board.Cells);
            if(cellChecked == null)
            {
                if(IsBoardSolved(board))
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
                    if (IsValid(board, cellChecked.XLocation, cellChecked.YLocation, possibleNum))
                    {
                        Board newBoard = new Board(board.ArrayCopy());
                        //Board newBoard = new 
                        newBoard.Cells[cellChecked.XLocation, cellChecked.YLocation].Value = possibleNum;
                        if (SolveBoard(newBoard))
                        {
                            if(!IsBoardSolved(this))
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
        public void FindPossibaleNumbersValues(Board board)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    board.Cells[i, j].PossibleNumbers.Clear();
                    for (int gussed_number = 1; gussed_number <= Globals.BoardSize; gussed_number++)
                    {
                        if (IsValid(board, i, j, gussed_number))
                        {
                            board.Cells[i, j].PossibleNumbers.Add(gussed_number);
                        }
                        else
                            board.Cells[i, j].PossibleNumbers.Remove(gussed_number);
                    }
                }
            }
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
        public static bool IsValid(Board board, int row, int col, int number)
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
