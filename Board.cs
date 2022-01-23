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
        public bool isBoardValid(int[,] board)
        {
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (board[i, j] != 0 && !IsValid(board, i, j, board[i, j]))
                        return false;
                }
            }
            return true;  
        }
        public bool SolveBoard(int[,] board)
        { 
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (board[i, j] == 0)
                    {
                        Console.WriteLine(i + ", " + j);
                        for (int possibleNum = 1; possibleNum <= Globals._boardSize; possibleNum++)
                        {
                            if (IsValid(board, i, j, possibleNum))
                            {
                                board[i, j] = possibleNum;

                                if (SolveBoard(board))
                                    return true;
                                else
                                    board[i, j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            _cells = board;
            return true;
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
    }
}
