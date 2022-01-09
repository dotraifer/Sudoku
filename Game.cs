using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Game
    {
        internal Board _board { get; set; }
        public Game(string board_string)
        {
            _board = new Board();
            _board.ResetBoard(GetBoard(board_string));
        }
        public int[,] GetBoard(string board_string)
        {
            int[] asciis = GetAsciiValues(board_string);
            int[, ] grid = BuildGrid(asciis);
            return grid;
        }
        public int[,] BuildGrid(int[] values)
        {
            if (Math.Sqrt(Math.Sqrt(values.Length)) % 1 != 0) 
                throw (new UnpossibleBoardSizeExeption("cant make a board out of " + values.Length + " numbers"));
            else
            {
                int face = (int)Math.Sqrt(values.Length);
                int[,] grid = new int[face, face];
                int arr_counter = 0;
                for (int i = 0; i < face; i++)
                {
                    for (int j = 0; j < face; j++)
                    {
                        grid[i, j] = values[arr_counter];
                        arr_counter++;
                    }
                }
                return grid;
            }
            
        }
        public int[] GetAsciiValues(string board_string)
        {
            char[] chars = board_string.ToCharArray();
            return GetValues(chars);
        }
        public int[] GetValues(char[] ascii_list)
        {
            int[] values = new int[ascii_list.Length];
            for(int i = 0;i < values.Length;i++)
            {
                int value = (int)ascii_list[i] - 48;
                if (value < 0 || value > Math.Sqrt(ascii_list.Length))
                    throw (new InvalidCharException("The char " + ascii_list[i] + " is illegal"));
                else
                    values[i] = value;
            }
            return values;
        }
    }
}
