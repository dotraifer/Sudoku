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
        private int _xLocation;
        public int XLocation
        {
            get { return _xLocation; }
            set { _xLocation = value; }
        }
        private int _yLocation;
        public int YLocation
        {
            get { return _yLocation; }
            set { _yLocation = value; }
        }
        public Cell(int value, int XLocation, int YLocation)
        {
            this.Value = value;
            this.PossibleNumbers = new List<int>();
            this.XLocation = XLocation;
            this.YLocation = YLocation;

        }
    }
}
