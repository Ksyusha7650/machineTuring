using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace machineTuring
{
    public struct Cell
    {
       public Char row;
       public String col;
       public String data;

        public Cell(String columnCell, Char rowCell, String dataCell)
        {
            col = columnCell;
            row = rowCell;
            data = dataCell;
        }
    }

    public struct CellStrip
    {
        public Int32 index;
        public Char data;

    }


}
