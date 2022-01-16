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
            _board = new Board(GetMatrix(board_string));
        }
        public Board GetBoard() { return _board; }
        public void SetBoard(Board board) { this._board = board; }

        /// <summary>
        /// this function take the string that represents the board, and return it as a matrix(int[,]) after converting asciis.
        /// </summary>
        /// <param name="board_string">the string that represents the sudoku</param>
        /// <returns>grid - the board as a matrix of integers</returns>
        public int[,] GetMatrix(string board_string)
        {

            int[] asciis = GetAsciiValues(board_string);
            return BuildGrid(asciis);
        }

        /// <summary>
        /// this function checks if we got a legal size of string, and return the matrix that represent the board
        /// </summary>
        /// <param name="values">a 1D array of integers that reapreasent the board</param>
        /// <exception cref="UnpossibleBoardSizeExeption">will throw if we got illegal board size</exception>
        /// <returns>grid - the board as a matrix of integers </returns>
        public int[,] BuildGrid(int[] values)
        {
            if (Math.Sqrt(Math.Sqrt(values.Length)) % 1 != 0) 
                throw (new UnpossibleBoardSizeExeption("cant make a board out of " + values.Length + " numbers"));
            else
            {
                Globals._boardSize = (int)Math.Sqrt(values.Length);
                int[,] grid = new int[Globals._boardSize, Globals._boardSize];
                int arr_counter = 0;
                for (int i = 0; i < Globals._boardSize; i++)
                {
                    for (int j = 0; j < Globals._boardSize; j++)
                    {
                        grid[i, j] = values[arr_counter];
                        arr_counter++;
                    }
                }
                return grid;
            }
            
        }

        /// <summary>
        /// this function take a string, make it an array, and then convert the chars to their value as integers
        /// </summary>
        /// <param name="board_string"> the string that represent the board</param>
        /// <returns>array of integers that represents the board</returns>
        public int[] GetAsciiValues(string board_string)
        {
            // make an array
            char[] chars = board_string.ToCharArray();
            return GetValues(chars);
        }

        /// <summary>
        /// this function go over the array, and convert every char to his integer value
        /// </summary>
        /// <param name="ascii_list"> array of chars that reprsent the board</param>
        /// <exception cref="InvalidCharException">will throw if a char in the string is out of our sudoku range</exception>
        /// <returns>array of integers that represent the board</returns>
        public int[] GetValues(char[] ascii_list)
        {
            int[] values = new int[ascii_list.Length];
            for(int i = 0;i < values.Length;i++)
            {
                // convert to int
                int value = (int)ascii_list[i] - 48;
                // if out of range
                if (value < 0 || value > Math.Sqrt(ascii_list.Length))
                    throw (new InvalidCharException("The char " + ascii_list[i] + " is illegal"));
                else
                    values[i] = value;
            }
            return values;
        }

        public int[,] SolveBoard()
        {
            int[,] cells = _board.GetCells();
            _board.SolveBoard(cells);
            return _board.GetCells();
        }
    }
}
