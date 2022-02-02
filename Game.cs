using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Game
    {
        private Board _board;
        public Game(string board_string)
        {
            // make the string to a metrix, to board
            _board = new Board(BuildGrid(board_string));
        }
        public Board GetBoard() { return _board; }
        public void SetBoard(Board board) { this._board = board; }

        /// <summary>
        /// this function checks if we got a legal size of string, and return the matrix that represent the board
        /// </summary>
        /// <param name="board_strin_string">a string that reapreasent the board</param>
        /// <exception cref="UnpossibleBoardSizeExeption">will throw if we got illegal board size</exception>
        /// <returns>grid - the board as a matrix of integers </returns>
        public Cell[,] BuildGrid(string board_string)
        {
            // if board is empty, or that his length is illegal
            if (board_string.Length == 0 || Math.Sqrt(Math.Sqrt(board_string.Length)) % 1 != 0)
                throw (new UnpossibleBoardSizeExeption("cant make a board out of " + board_string.Length + " numbers"));
            else
            {
                // the size of the board
                Globals.BoardSize = (int)Math.Sqrt(board_string.Length);
                // the size of the smallbox
                Globals.SmallBoxSize = (int)Math.Sqrt(Globals.BoardSize);
                Cell[,] grid = new Cell[Globals.BoardSize, Globals.BoardSize];
                int arr_counter = 0;
                for (int i = 0; i < Globals.BoardSize; i++)
                {
                    for (int j = 0; j < Globals.BoardSize; j++)
                    {
                        // from char to int
                        int value = (int)(board_string[arr_counter] - '0');
                        // if value is bigger then the biggest possible number
                        if (value < 0 || value > Globals.BoardSize)
                            throw (new InvalidCharException("the char " + board_string[arr_counter] + " is illegal"));
                        else
                        {
                            // put in grid
                            grid[i, j] = new Cell(value, i, j);
                            arr_counter++;
                        }
                    }
                }
                return grid;
            }

        }


        /// <summary>
        /// this function calls solve the board(calls the solvings methods), then return the result as a string
        /// </summary>
        /// <param name="board">the board to solve</param>
        /// <returns>the string of the result</returns>
        public string SolveBoard(Board board)
        {
            // if the board is invalid
            if(!BoardUtils.IsBoardValid(board))
                throw (new InvalidBoardException("board is not valid"));
            // if the board cannot be solved 
            if (!_board.SolveBoard(board) || !BoardUtils.IsBoardValid(board))
                throw (new InsolubleBoardException("board is Insoluble"));
            // return as string
            return ReturnToString(board.Cells);
        }


        /// <summary>
        /// this function takes a matrix of int and return him as string
        /// </summary>
        /// <param name="grid">the grid to make a string</param>
        /// <returns>the string of the result</returns>
        public string ReturnToString(Cell[,] grid)
        {
            string result = "";
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    result += (char)(grid[i, j].Value + 48);
                }
            }
            return result;
        }

    }
}
