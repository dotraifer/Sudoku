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
            Cells = new Cell[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
