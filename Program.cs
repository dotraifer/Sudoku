using System;
using System.IO;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string board_string;
            while (true)
            {
                board_string = null;
                Gui.PrintManu();
                string manuChoose = Console.ReadLine();
                manuChoose = manuChoose.ToLower();
                switch (manuChoose)
                {
                    case "console":
                        Console.WriteLine("~enter a string that would represent the board you want to solve:");
                        board_string = Console.ReadLine();
                        break;
                    case "file":
                        Console.WriteLine("~enter the text file path:");
                        board_string = ReadFromFile();
                        break;
                    case "exit":
                        Console.WriteLine("thank you for using!");
                        Environment.Exit(1);
                        break;

                }
                string result_board = Solver.Solve(board_string);
                // TODO : clean the main
                if (result_board != null)
                {
                    Gui.PrintBoard(board_string);
                    Gui.PrintBoard(result_board);
                }
            }
        }
        public static string ReadFromFile()
        {
            string path = Console.ReadLine();
            path = path.Replace("\"", "");
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
