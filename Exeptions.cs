using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class UnpossibleBoardSizeExeption : Exception 
    {
        public UnpossibleBoardSizeExeption(String massage) : base(massage) { }
    }
    public class InvalidCharException : Exception
    {
        public InvalidCharException(String massage) : base(massage) { }
    }
    public class InsolubleBoardException : Exception
    {
        public InsolubleBoardException(String massage) : base(massage) { }
    }
}
