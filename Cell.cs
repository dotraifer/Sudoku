using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Cell
    {
        internal int value { get; set; }
        private readonly bool is_constant;

        public Cell(int value, bool is_constant)
        {
            this.value = value;
            this.is_constant = is_constant;
        }
        public void reset_possible_numbers(int board_size)
        {
            for(int i = 1;i <= board_size;i++)
            {

            }
        }
    }
}
