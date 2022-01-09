using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class Board
    {
        internal Cell[,] Cells { get; set; }
        public void ResetBoard(int[,] matrix)
        {
            Cells = new Cell[Globals._boardSize, Globals._boardSize];
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    if (matrix[i, j] != 0)
                        Cells[i, j] = new Cell(matrix[i, j], true);
                    else
                        Cells[i, j] = new Cell(0, false);
                }
            }
        }
    }
}
