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
            if (board_string.Length == 0 || Math.Sqrt(Math.Sqrt(board_string.Length)) % 1 != 0)
                throw (new UnpossibleBoardSizeExeption("cant make a board out of " + board_string.Length + " numbers"));
            else
            {
                Globals._boardSize = (int)Math.Sqrt(board_string.Length);
                Cell[,] grid = new Cell[Globals._boardSize, Globals._boardSize];
                int arr_counter = 0;
                for (int i = 0; i < Globals._boardSize; i++)
                {
                    for (int j = 0; j < Globals._boardSize; j++)
                    {
                        int value = (int)(board_string[arr_counter] - '0');
                        if (value < 0 || value > Globals._boardSize)
                            throw (new InvalidCharException("the char " + board_string[arr_counter] + " is illegal"));
                        else
                        {
                            if(value == 0)
                                grid[i, j] = new Cell(value, false);
                            else
                                grid[i, j] = new Cell(value, true);
                            arr_counter++;
                        }
                    }
                }
                return grid;
            }

        }

        public string SolveBoard(Board board)
        {
            if(!Solver.IsBoardValid(board))
                throw (new InvalidBoardException("board is not valid"));
            if (!_board.SolveBoard(board) || !Solver.IsBoardValid(board))
                throw (new InsolubleBoardException("board is Insoluble"));
            return ReturnToArray(board.GetCells());
        }

        public string ReturnToArray(Cell[,] grid)
        {
            string result = "";
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    result += (char)(grid[i, j]._value + 48);
                }
            }
            return result;
        }

    }
}
