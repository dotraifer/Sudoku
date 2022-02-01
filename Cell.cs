using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class Cell
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private List<int>  _possibleNumbers;
        public List<int> PossibleNumbers
        {
            get { return _possibleNumbers; }
            set { _possibleNumbers = value; }
        }
        public Cell(int value)
        {
            this.Value = value;
            this.PossibleNumbers = new List<int>();
        }
    }
}
