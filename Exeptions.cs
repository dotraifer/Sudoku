using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class UnpossibleBoardSizeExeption : Exception
    {
        public UnpossibleBoardSizeExeption(String massage) : base(string.Format("Can't make a board out of {0} numbers", massage)) { }
    }
    public class InvalidCharException : Exception
    {
        public InvalidCharException(String massage) : base(string.Format("the char {0} is illegal", massage)) { }
    }
    public class InsolubleBoardException : Exception
    {
        public InsolubleBoardException(String massage) : base("The board is Insoluble") { }
    }
    public class InvalidBoardException : Exception
    {
        public InvalidBoardException(String massage) : base("Invalid board has been enterd") { }
    }
}
