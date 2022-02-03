using System;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string board_string;
            while (true)
            {
                board_string = HandaleUserChoose();
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                string result_board = Solver.Solve(board_string);
                watch.Stop();
                PrintGame(board_string, result_board, watch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// static function that get choose from the user, than update the string by the string he put, and return the string
        /// </summary>
        /// <returns>the string we want to solve</returns>
        public static string HandaleUserChoose()
        {
            string board_string = null;
            Gui.PrintManu();
            string manuChoose = Console.ReadLine();
            manuChoose = manuChoose.ToLower();
            switch (manuChoose)
            {
                // if he put in the console
                case "console":
                    Console.WriteLine("~enter a string that would represent the board you want to solve:");
                    board_string = Console.ReadLine();
                    break;
                // if he put from file
                case "file":
                    board_string = ReadFromFile();
                    break;
                // if he want to exit
                case "exit":
                    Console.WriteLine("thank you for using!");
                    Environment.Exit(1);
                    break;
                // if none of those
                default:
                    Console.WriteLine("unvalid choose");
                    break;

            }
            return board_string;
        }

        /// <summary>
        /// this function print the game, he print the board we got, the board after solving and the time took to solve
        /// </summary>
        /// <remarks>to print the boards, we call the function PrintBoard from the Gui class</remarks>
        /// <param name="beforeSolve">the board before the solve-as string</param>
        /// <param name="AfterSolve">the board after the solve-as string</param>
        /// <param name="timeToSolve">the time it took to solve</param>
        public static void PrintGame(string beforeSolve, string AfterSolve, long timeToSolve)
        {
            if (AfterSolve != null)
            {
                Gui.PrintBoard(beforeSolve);
                Gui.PrintBoard(AfterSolve);
               Console.WriteLine($"Execution Time: {timeToSolve} ms");
            }
        }

        /// <summary>
        /// static function that handeles a file Choose of the user
        /// </summary>
        /// <remarks>open the file system for the user to choos his file</remarks>
        /// <returns>the string we got from the file, or null if we got into a problam</returns>
        public static string ReadFromFile()
        {
            string path = null;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "TXT files|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
                path = fileDialog.FileName;
            try {
                return File.ReadAllText(@path);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("file directory not found");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("file not found");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("empty path name is not legal");
            }
            catch (Exception e)
            {
                Console.WriteLine("unknown problem with file opening\n" + e);
            }
            return null;
        }
    }
}
