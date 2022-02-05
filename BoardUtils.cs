using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
<<<<<<< HEAD
    public static class BoardUtils
    {
=======

    /// <summary>
    /// This class contains the static methods that used on boards
    /// </summary>
    public static class BoardUtils
    {

        /// <summary>
        /// static function that takes a board and check if the board is legal/valid
        /// </summary>
        /// <param name="board">the board we check if he is valid</param>
        /// <returns>True if board is valid False otherwise</returns>
>>>>>>> Dev
        public static bool IsBoardValid(Board board)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
<<<<<<< HEAD
=======
                    // if not 0 and not valid
>>>>>>> Dev
                    if (board.Cells[i, j].Value != 0 && !IsValid(board, i, j, board.Cells[i, j].Value))
                        return false;
                }
            }
            return true;
        }

<<<<<<< HEAD


        /// <summary>
        /// this function will check if to put number in the row and col coordinate is valid
=======
        /// <summary>
        /// static function that will check if to put number in the row and col coordinate is valid
>>>>>>> Dev
        /// </summary>
        /// <param name="board">the board state we check on</param>
        /// <param name="row"> the row we check</param>
        /// <param name="col"> the col we check</param>
        /// <param name="number">the number we check</param>
        /// <returns>True if valid False otherwise</returns>
        public static bool IsValid(Board board, int row, int col, int number)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                //check row  
                if (board.Cells[i, col].Value != 0 && i != row && board.Cells[i, col].Value == number)
                    return false;
                //check column  
                if (board.Cells[row, i].Value != 0 && i != col && board.Cells[row, i].Value == number)
<<<<<<< HEAD
                    return false;
                //check smaller box block  
            }
=======
                    return false; 
            }
            //check smaller box block 
>>>>>>> Dev
            if (!IsSmallBoxValid(board, row, col, number))
                return false;
            return true;
        }

        /// <summary>
<<<<<<< HEAD
        /// this function check if the number is already in the small box, or it is possible to put him in the rowand col coorinate
=======
        /// static function that heck if the number is already in the small box, or it is possible to put him in the rowand col coorinate
>>>>>>> Dev
        /// </summary>
        /// <param name="board">the board state we check on</param>
        /// <param name="row"> the row we check</param>
        /// <param name="col"> the col we check</param>
        /// <param name="number">the number we check</param>
        /// <returns>True if it valid to put the number in the small box, false otherwise</returns>
        public static bool IsSmallBoxValid(Board board, int row, int col, int number)
        {
<<<<<<< HEAD
            // 010040050407000602820600074000010500500000003004050000960003045305000801070020030
            // 000260701680070090190004500820100040004602900050003028009300074040050036703018000
            int smallBoxSize = (int)Math.Sqrt(Globals.BoardSize);
=======
            int smallBoxSize = (int)Math.Sqrt(Globals.BoardSize);
            // find the coordinate of the lowest leftiest cell in the box of the number
>>>>>>> Dev
            int firstBoxRow = row - row % smallBoxSize;
            int firstBoxColumn = col - col % smallBoxSize;
            for (int i = firstBoxRow; i < firstBoxRow + smallBoxSize; i++)
            {
                for (int j = firstBoxColumn; j < firstBoxColumn + smallBoxSize; j++)
                {
<<<<<<< HEAD
=======
                    // if the it has the alue and it's not the cell we check on
>>>>>>> Dev
                    if (board.Cells[i, j].Value == number && !(i == row && j == col))
                        return false;
                }
            }
            return true;

        }
<<<<<<< HEAD
        public static bool IsBoardSolved(Board board)
        {
            for (int i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < board.Cells.GetLength(1); j++)
                {
=======


        /// <summary>
        /// static function that takes a board and check if the board is solved(has no 0)
        /// </summary>
        /// <param name="board">the board we check if he is solved</param>
        /// <returns>True if the board is solver, false otherwise</returns>
        public static bool IsBoardSolved(Board board)
        {
            for (int i = 0; i < Globals.BoardSize; i++)
            {
                for (int j = 0; j < Globals.BoardSize; j++)
                {
                    // if we found 0 - it is not solved
>>>>>>> Dev
                    if (board.Cells[i, j].Value == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
