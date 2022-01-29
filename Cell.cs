using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class Cell
    {
        public int _value { get; set; }
        public int _tempValue { get; set; }
        public bool _is_constant { get; set; }
        public List<int> _possibleNumbers { get; set; }
        public Cell(int value, bool is_constant)
        {
            this._value = value;
            this._is_constant = is_constant;
            this._tempValue = value;
            this._possibleNumbers = new List<int>();
        }
    }
}
