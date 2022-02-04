using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{

    /// <summary>
    /// this instance class reprosent cell in the board- single slot
    /// </summary>
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
            // the cell value
            this.Value = value;
            // list pf the cell possible numbers
            this.PossibleNumbers = new List<int>();
            // the cell x coordinate
            this.XLocation = XLocation;
            // the cell y coordinate
            this.YLocation = YLocation;

        }
    }
}
