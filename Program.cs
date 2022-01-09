using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("~enter a string that would represent the _board you want to solve~");
                String board_string = Console.ReadLine();
                int [,] result_board = Solve(board_string);
                Gui.PrintBoard(result_board);
            }
        }
        public static int[,] Solve(string board_string)
        {
            int[,] matrix;
            Game game = new Game(board_string);
            return MakeCellToMartrix(game._board);
        }
        public static int[,] MakeCellToMartrix(Board board)
        {
            // convert the cells matrix to int matrix of values
            int[,] matrix = new int[board.Cells.GetLength(0), board.Cells.GetLength(1)];
            for (int i = 0; i < Globals._boardSize; i++)
            {
                for (int j = 0; j < Globals._boardSize; j++)
                {
                    matrix[i, j] = board.Cells[i, j].value;
                }
            }
            return matrix;
        }
    }
}
