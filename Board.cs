using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{

    /// <summary>
    /// Instance class that represents a board - and containd a matrix of the cells in the board
    /// </summary>
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


        /// <summary>
        ///  this function gets a board and call the functions to solve him
        /// </summary>
        /// <remarks>
        /// the function is called fom the backtracking and in fact recursive
        /// for every number we guess in the backtracking - we call the function, it calls the logical solver, and then the backtracking, 
        /// so that for every board we guess we uses the logical solver to see if it has sulotion way faster.
        /// </remarks>
        /// <param name="board">the board we want to solve</param>
        /// <returns>True if the board has a sulotion, else false</returns>
        public bool SolveBoard(Board board)
        {
            // while the logical solver still find new cells values
            SolvingTactics.LogicalSolveing(board);
            return BackTracking(board);
        }


        /// <summary>
        /// this function guesses number in cell that has the smallest number of opptions, and then call the solve function for a copy of the board, 
        ///that will activate the logical solver, and the will call the backtracking again for the new board
        /// </summary>
        /// <param name="board">the board we want to backtrack on</param>
        /// <returns>True if it found a sulotion, else false</returns>
        public bool BackTracking(Board board)
        {
            Cell cellChecked = FindLeastOptionsCell(board.Cells);
            // if there is no cells that still has options, we solve the board or that we got to a deadend(no sulotion)
            if(cellChecked == null)
            {
                if(BoardUtils.IsBoardSolved(board))
                {
                    // put in cells the solved board
                    Cells = board.MatrixCopy();
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
                        // create new board
                        Board newBoard = new Board(board.MatrixCopy());
                        // put the value in it
                        newBoard.Cells[cellChecked.XLocation, cellChecked.YLocation].Value = possibleNum;
                        if (SolveBoard(newBoard))
                        {
                            if(!BoardUtils.IsBoardSolved(this))
                                Cells = newBoard.MatrixCopy();
                            return true;
                        }
                                
                    }                  
                }
                return false;
            }
            return true;
        }


        /// <summary>
        /// this function copy matrix of Cell by value and return the new Mmtrix 
        /// </summary>
        /// <returns>the bnew Cell matrix</returns>
        public Cell[,] MatrixCopy()
        {
            Cell[,] result = new Cell[Cells.GetLength(0), Cells.GetLength(1)]; //Create a result array that is the same length as the input array
            for (int x = 0; x < Cells.GetLength(0); ++x) //Iterate through the horizontal rows of the two dimensional array
            {
                for (int y = 0; y < Cells.GetLength(1); ++y) //Iterate throught the vertical rows
                {
                    result[x, y] = new Cell(Cells[x,y].Value, Cells[x, y].XLocation, Cells[x, y].YLocation); //Copy the cell
                }
            }
            return result;
        }


        /// <summary>
        /// this fuction finds the cell with the smallest number of possible opptions, and return it
        /// </summary>
        /// <param name="cells">the matrix of cells we want to search in</param>
        /// <returns>the Cell with smallest number of possible opptions</returns>
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
