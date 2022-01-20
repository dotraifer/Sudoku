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
        /// <param name="values">a 1D array of integers that reapreasent the board</param>
        /// <exception cref="UnpossibleBoardSizeExeption">will throw if we got illegal board size</exception>
        /// <returns>grid - the board as a matrix of integers </returns>
        public int[,] BuildGrid(string board_string)
        {
            if (Math.Sqrt(Math.Sqrt(board_string.Length)) % 1 != 0)
                throw (new UnpossibleBoardSizeExeption("cant make a board out of " + board_string.Length + " numbers"));
            else
            {
                Globals._boardSize = (int)Math.Sqrt(board_string.Length);
                int[,] grid = new int[Globals._boardSize, Globals._boardSize];
                int arr_counter = 0;
                for (int i = 0; i < Globals._boardSize; i++)
                {
                    for (int j = 0; j < Globals._boardSize; j++)
                    {
                        grid[i, j] = (int)(board_string[arr_counter] - '0');
                        arr_counter++;
                    }
                }
                return grid;
            }

        }

        public string SolveBoard()
        {
            int[,] cells = _board.GetCells();
            
            if (!_board.SolveBoard(cells) || !_board.isBoardValid(cells))
                throw (new InsolubleBoardException("board is Insoluble"));
            return ReturnToArray(_board.GetCells());
        }
        public string ReturnToArray(int[,] grid)
        {
            string result = "";
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    result += (char)(grid[i, j] + 48);
                }
            }
            Console.WriteLine(result);
            return result;
        }

    }
}
