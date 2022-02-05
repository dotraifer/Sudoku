using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{

    /// <summary>
    /// this static class contain out global varibales
    /// </summary>
    public static class Globals
    {
        // the board size(1 for 1on1, 4 for 4on4 and so on...)
        public static int BoardSize = 0;
        // the small box size(2 in 4on4, 3 in 9on9 and so on...)
        public static int SmallBoxSize = 0;
        // the number of digits in the biggest possible number(1 in 9on9, 2 in 16on16, 3 in 100on100 and so on...)
        public static int BiggestNumberSize = 1;
    }
}
