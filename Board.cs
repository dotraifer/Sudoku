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
                has_changed = SolvingTactics.LogicalSolveing(board);
            }
            return BackTracking(board);
        }
        public bool BackTracking(Board board)
        {
            Cell cellChecked = FindLeastOptionsCell(board.Cells);
            if(cellChecked == null)
            {
                if(BoardUtils.IsBoardSolved(board))
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
                    if (BoardUtils.IsValid(board, cellChecked.XLocation, cellChecked.YLocation, possibleNum))
                    {
                        Board newBoard = new Board(board.ArrayCopy());
                        //Board newBoard = new 
                        newBoard.Cells[cellChecked.XLocation, cellChecked.YLocation].Value = possibleNum;
                        if (SolveBoard(newBoard))
                        {
                            if(!BoardUtils.IsBoardSolved(this))
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
