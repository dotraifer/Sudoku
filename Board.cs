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
        public bool IsBoardValid()
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (_cells[i, j] != 0 && !IsValid(_cells, i, j, _cells[i, j]))
                        return false;
                }
            }
            return true;  
        }
        public bool SolveBoard()
        {
            bool has_changed = true;
            while (has_changed)
            {
                printmatrix(_cells);
                Console.WriteLine();
                has_changed =  FindOnlyPossibility();
                printmatrix(_cells);
            }
            return backtracking();
        }
        public bool backtracking()
        {
            int[,] temp = new int[Globals._boardSize, Globals._boardSize];
            bool has_changed = true;
            Console.WriteLine("hey");
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (_cells[i, j] == 0)
                    {
                        for (int possibleNum = 1; possibleNum <= Globals._boardSize; possibleNum++)
                        {
                            if (IsValid(_cells, i, j, possibleNum))
                            {
                                _cells[i, j] = possibleNum;
                                if (DoesOnlyPossible(_cells, i ,j , possibleNum))
                                {
                                    for (int k = 0; k < Globals._boardSize; k++)
                                    {
                                        for (int d = 0; d < Globals._boardSize; d++)
                                        {
                                            temp[k, d] = _cells[k, d];
                                        }
                                    }
                                    while (has_changed)
                                    {
                                        Console.WriteLine("before:");
                                        printmatrix(_cells);
                                        has_changed = FindOnlyPossibility();
                                        Console.WriteLine("after:");
                                        printmatrix(_cells);
                                        Console.WriteLine(has_changed);
                                    }
                                    if (isBoardSolved(_cells))
                                    {
                                        Console.WriteLine("printdfgf");
                                        return true;
                                    }
                                    else
                                    {
                                        for (int k = 0; k < Globals._boardSize; k++)
                                        {
                                            for (int d = 0; d < Globals._boardSize; d++)
                                            {
                                                _cells[k, d] = temp[k, d];
                                            }
                                        }
                                    }
                                }
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
        public int[,] copyMatrix(int[,] gettingMat, int[,] SettingMat)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    gettingMat = SettingMat;
                }
            }
            return gettingMat;
        }
        public bool isBoardSolved(int[,] board)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (board[i, j] == 0)
                        return false;
                }
            }
            return true;
        }
        public bool FindOnlyPossibility()
        {
            bool has_changed = false;
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if(_cells[i,j] == 0)
                    {
                        for (int gussed_number = 1; gussed_number <= Globals._boardSize; gussed_number++)
                        {
                            if(IsValid(_cells, i, j, gussed_number) && DoesOnlyPossible(_cells, i , j, gussed_number))
                            {
                                _cells[i, j] = gussed_number;
                                Console.WriteLine(i + "," + j + "," + gussed_number);
                                has_changed = true;
                                break;
                            }
                        }
                    }
                }
            }
            return has_changed;
        }
        public bool DoesOnlyPossible(int[,] board ,int row, int col, int gussed_number)
        {
            bool breakLoops = false;
            bool rowFlag = true;
            bool colFlg = true;
            bool smallBoxFlag = true;
            int smallBoxSize = (int)Math.Sqrt(Globals._boardSize);
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            for (int i = 0; i < Globals._boardSize; i++)
            {
                if (board[i, col] == 0 && i != row && rowFlag)
                    rowFlag = !IsValid(board, i, col, gussed_number);
                if (board[row, i] == 0 && i != col && colFlg)
                    colFlg = !IsValid(board, row, i, gussed_number);
            }
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board[i, j] == 0 && !(i == row && j == col))
                    {
                        smallBoxFlag = !IsValid(board, i, j, gussed_number);
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
            return rowFlag || colFlg || smallBoxFlag;

        }
        public bool IsValid(int[,] board, int row, int col, int number)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                //check row  
                if (board[i, col] != 0 && i != row&& board[i, col] == number)
                    return false;
                //check column  
                if (board[row, i] != 0 && i != col && board[row, i] == number)
                    return false;
                //check smaller box block  
            }
            if (!IsSmallBoxValid(board, row, col, number))
                return false;
            return true;
        }
        public bool IsSmallBoxValid(int[,] board, int row, int col, int number)
        {
            // 010040050407000602820600074000010500500000003004050000960003045305000801070020030
            // 000260701680070090190004500820100040004602900050003028009300074040050036703018000
            int smallBoxSize = (int)Math.Sqrt(Globals._boardSize);
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
                    if (board[i, j] == number && !(i == row && j == col))
                        return false;
                }
            }
            return true;

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
