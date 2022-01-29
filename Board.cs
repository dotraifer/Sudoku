using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Board
    {
        private int[,] _cells;
        public Board(int[,] cells)
        {
            this._cells = cells;
        }
        public int[,] GetCells()
        {
            return _cells;
        }
        public void SetCells(int[,] cells)
        {
            this._cells = cells;
        }
        public bool SolveBoard()
        {
            return SolveBoard(_cells);
        }
        public bool SolveBoard(int [,] board)
        {
            bool has_changed = true;
            while (has_changed)
            {
                printmatrix(board);
                Console.WriteLine();
                has_changed =  LogicalSolveing(board);
                printmatrix(board);
            }
            return backtracking();
        }
        public bool backtracking()
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (_cells[i, j] == 0)
                    {
                        for (int possibleNum = 1; possibleNum <= Globals._boardSize; possibleNum++)
                        {
                            if (Solver.IsValid(_cells, i, j, possibleNum))
                            {
                                _cells[i, j] = possibleNum;
                                if (backtracking())
                                    return true;
                                else
                                    _cells[i, j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        public int[,] arrayCopy(int[,] input)
        {
            int[,] result = new int[input.GetLength(0), input.GetLength(1)]; //Create a result array that is the same length as the input array
            for (int x = 0; x < input.GetLength(0); ++x) //Iterate through the horizontal rows of the two dimensional array
            {
                for (int y = 0; y < input.GetLength(1); ++y) //Iterate throught the vertical rows, to add more dimensions add another for loop for z
                {
                    result[x, y] = input[x, y]; //Change result x,y to input x,y
                }
            }
            return result;
        }
        public bool LogicalSolveing(int [,] board)
        {
            bool has_changed = false;
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if(board[i,j] == 0)
                    {
                        has_changed = FindOnlyPossibility(board, i , j);
                    }
                }
            }
            return has_changed;
        }
        public bool FindOnlyPossibility(int[,] board, int row, int col)
        {
            bool has_changed = false;
            for (int gussed_number = 1; gussed_number <= Globals._boardSize; gussed_number++)
            {
                if (Solver.IsValid(board, row, col, gussed_number) && DoesOnlyPossible(board, row, col, gussed_number))
                {
                    board[row, col] = gussed_number;
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
        public bool DoesOnlyPossible(int[,] board ,int row, int col, int gussed_number)
        {
            bool breakLoops = false;
            // flag that say if the number is the only possibility according to the row
            bool rowFlag = true;
            // flag that say if the number is the only possibility according to the col
            bool colFlg = true;
            // flag that say if the number is the only possibility according to the small Box
            bool smallBoxFlag = true;
            int smallBoxSize = (int)Math.Sqrt(Globals._boardSize);
            // get the coordinates of the first square in the small box
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            // if each row, col or small box, check if there is other box that the number can be applied to
            for (int i = 0; i < Globals._boardSize; i++)
            {
                // check row
                if (board[i, col] == 0 && i != row && rowFlag)
                    rowFlag = !Solver.IsValid(board, i, col, gussed_number);
                // check col
                if (board[row, i] == 0 && i != col && colFlg)
                    colFlg = !Solver.IsValid(board, row, i, gussed_number);
            }
            // check small box
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board[i, j] == 0 && !(i == row && j == col))
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
        public void printmatrix(int[,] board)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
