using System;
using System.Collections.Generic;

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
<<<<<<< HEAD
            FindPossibaleNumbersValues(board);
            bool has_changed = true;
            while (has_changed)
            {
                has_changed = SolvingTactics.LogicalSolveing(board);
            }
            return BackTracking(board);
=======
            // the logical solver find new cells values
            SolvingTactics.LogicalSolveing(board);
            return GuessNumbers(board);
>>>>>>> Dev
        }


        /// <summary>
        /// this function guesses number in cell that has the smallest number of opptions, and then call the solve function for a copy of the board, 
        ///that will activate the logical solver, and the will call the backtracking again for the new board
        /// </summary>
        /// <param name="board">the board we want to backtrack on</param>
        /// <returns>True if it found a sulotion, else false</returns>
        public bool GuessNumbers(Board board)
        {
            Cell cellChecked = FindLeastOptionsCell(board.Cells);
            // if there is no cells that still has options, we solve the board or that we got to a deadend(no sulotion)
            if(cellChecked == null)
            {
<<<<<<< HEAD
                if(IsBoardSolved(board))
=======
                if(BoardUtils.IsBoardSolved(board))
>>>>>>> Dev
                {
                    // put in cells the solved board
                    Cells = board.MatrixCopy();
                    return true;
                }
                return false;
            }
            // if 0
            if (cellChecked.Value == 0)
            {
                // for every possible num
                foreach (int possibleNum in cellChecked.PossibleNumbers)
                {
<<<<<<< HEAD
                    if (IsValid(board, cellChecked.XLocation, cellChecked.YLocation, possibleNum))
=======
                    if (BoardUtils.IsValid(board, cellChecked.XLocation, cellChecked.YLocation, possibleNum))
>>>>>>> Dev
                    {
                        // create new board
                        Board newBoard = new Board(board.MatrixCopy());
                        // put the value in it
                        newBoard.Cells[cellChecked.XLocation, cellChecked.YLocation].Value = possibleNum;
                        // try to solve the new board
                        if (SolveBoard(newBoard))
                        {
<<<<<<< HEAD
                            if(!IsBoardSolved(this))
                                Cells = newBoard.ArrayCopy();
=======
                            // if cells matrix isn't solved, copy to cells
                            if(!BoardUtils.IsBoardSolved(this))
                                Cells = newBoard.MatrixCopy();
>>>>>>> Dev
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
            for (int x = 0; x < Globals.BoardSize; ++x) 
            {
                for (int y = 0; y < Globals.BoardSize; ++y)
                {
                    //Copy the cell
                    result[x, y] = new Cell(Cells[x,y].Value, Cells[x, y].XLocation, Cells[x, y].YLocation); 
                }
            }
            return result;
        }
<<<<<<< HEAD
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
=======


        /// <summary>
        /// this fuction finds the cell with the smallest number of possible opptions, and return it
        /// </summary>
        /// <param name="cells">the matrix of cells we want to search in</param>
        /// <returns>the Cell with smallest number of possible opptions</returns>
>>>>>>> Dev
        public Cell FindLeastOptionsCell(Cell[,] cells)
        {
            // saves the cell witht he smallest number of possibilities
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
<<<<<<< HEAD
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
=======
>>>>>>> Dev
    }
}
