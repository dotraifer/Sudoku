using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Board
    {
        private Cell[,] _cells;
        public Board(Cell[,] cells)
        {
            this._cells = cells;
        }
        public Cell[,] GetCells()
        {
            return _cells;
        }
        public void SetCells(Cell[,] cells)
        {
            this._cells = cells;
        }
        public bool SolveBoard()
        {
            return SolveBoard(_cells);
        }
        public bool SolveBoard(Cell [,] board)
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
                    if (_cells[i, j]._value == 0)
                    {
                        foreach (int possibleNum in _cells[i, j]._possibleNumbers)
                        {
                            if (Solver.IsValid(_cells, i, j, possibleNum))
                            {
                                _cells[i, j]._value = possibleNum;
                                if (backtracking())
                                    return true;
                                else
                                    _cells[i, j]._value = 0;
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
        public bool LogicalSolveing(Cell [,] board)
        {
            int listLength;
            bool has_changed = false;
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if(board[i,j]._value == 0)
                    {
                        if (!has_changed)
                        {
                            has_changed = FindOnlyPossibility(board, i, j);
                            listLength = board[i, j]._possibleNumbers.Count;
                            foreach(int d in board[i, j]._possibleNumbers)
                                Console.Write("no" + d);
                            Console.WriteLine();
                            if (!has_changed)
                            {
                                findGroups(board, i, j, listLength);
                                has_changed = FindOnlyPossibility(board, i, j);

                            }
                        }
                        else
                        {
                            FindOnlyPossibility(board, i, j);
                            listLength = board[i, j]._possibleNumbers.Count;
                            findGroups(board, i, j, listLength);
                            FindOnlyPossibility(board, i, j);
                        }
                    }
                }
            }
            return has_changed;
        }
        public bool findGroups(Cell[,] board, int row, int col, int listLength)
        {
            bool is_changed = false;
            int sameListCounterRow = 0;
            int sameListCounterCol = 0;
            int sameListCounterBox = 0;
            int smallBoxSize = (int)Math.Sqrt(Globals._boardSize);
            // get the coordinates of the first square in the small box
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            // if each row, col or small box, check if there is other box that the number can be applied to
            for (int i = 0; i < Globals._boardSize; i++)
            {
                // check row
                if (board[i, col]._value == 0 && i != row)
                {
                    if (compareLists(board[row, col]._possibleNumbers, board[i, col]._possibleNumbers))
                        sameListCounterRow++;
                }
                // check col
                if (board[row, i]._value == 0 && i != col)
                {
                    if (compareLists(board[row, col]._possibleNumbers, board[row, i]._possibleNumbers))
                        sameListCounterCol++;
                }
            }
            // check small box
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board[i, j]._value == 0 && !(i == row && j == col))
                    {
                        if (compareLists(board[row, col]._possibleNumbers, board[row, i]._possibleNumbers))
                            sameListCounterBox++;
                    }
                }
            }
            if (sameListCounterRow == listLength)
            {
                deleteOptionsFromRow(board, row, board[row, col]._possibleNumbers);
                is_changed = true;
            }
            if (sameListCounterCol == listLength)
            {
                deleteOptionsFromRow(board, col, board[row, col]._possibleNumbers);
                is_changed = true;
            }
            if (sameListCounterCol == listLength)
            {
                is_changed = true;
                deleteOptionsFromBox(board, row, col, smallBoxSize, board[row, col]._possibleNumbers);
            }
            return is_changed;

        }
        public bool compareLists(List<int> list1, List<int> list2)
        {
            return list1.Equals(list2);
        }
        public void deleteOptionsFromRow(Cell[,] board, int row, List<int> toDelete)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                if (!compareLists(board[row, i]._possibleNumbers, toDelete))
                    board[row, i]._possibleNumbers = DeleteAllcoincide(board[row, i]._possibleNumbers, toDelete);
            }
        }
        public void deleteOptionsFromCol(Cell[,] board, int col, List<int> toDelete)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                if (!compareLists(board[i, col]._possibleNumbers, toDelete))
                    board[i, col]._possibleNumbers = DeleteAllcoincide(board[i, col]._possibleNumbers, toDelete);
            }
        }
        public void deleteOptionsFromBox(Cell[,] board, int row, int col,int boxSize, List<int> toDelete)
        {
            for (int i = row; i < row + boxSize; i++)
            {
                for (int j = 0; j < col + boxSize; j++)
                {
                    if (!compareLists(board[i, j]._possibleNumbers, toDelete))
                        board[i, j]._possibleNumbers = DeleteAllcoincide(board[i, j]._possibleNumbers, toDelete);
                }
            }
        }
        public List<int> DeleteAllcoincide(List<int> deletelist, List<int> toDeletelist)
        {
            foreach (int number in toDeletelist)
                deletelist.Remove(number);
            return deletelist;
        }
        public bool FindOnlyPossibility(Cell[,] board, int row, int col)
        {
            bool has_changed = false;
            if (board[row, col]._possibleNumbers.Count == 1)
            {
                board[row, col]._value = board[row, col]._possibleNumbers[0];
                has_changed = true;
            }

            for (int gussed_number = 1; gussed_number <= Globals._boardSize; gussed_number++)
            {
                if (Solver.IsValid(board, row, col, gussed_number) && DoesOnlyPossible(board, row, col, gussed_number))
                {
                    board[row, col]._is_constant = true;
                    board[row, col]._value = gussed_number;
                    board[row, col]._tempValue = gussed_number;
                    has_changed = true;
                    break;
                }
                else if(Solver.IsValid(board, row, col, gussed_number))
                {
                    if(!board[row, col]._possibleNumbers.Contains(gussed_number))
                        board[row, col]._possibleNumbers.Add(gussed_number);
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
        public bool DoesOnlyPossible(Cell[,] board ,int row, int col, int gussed_number)
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
                if (board[i, col]._value == 0 && i != row && rowFlag)
                    rowFlag = !Solver.IsValid(board, i, col, gussed_number);
                // check col
                if (board[row, i]._value == 0 && i != col && colFlg)
                    colFlg = !Solver.IsValid(board, row, i, gussed_number);
            }
            // check small box
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board[i, j]._value == 0 && !(i == row && j == col))
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
        public void printmatrix(Cell[,] board)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    Console.Write(board[i, j]._value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
