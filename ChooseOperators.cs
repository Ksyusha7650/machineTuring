using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using MoreLinq;

namespace machineTuring
{
    public partial class ChooseOperators : Form
    {
        public List<Cell> avaibleOperators = new List<Cell>();
        static CellStrip currentCell = new CellStrip();
        public ChooseOperators(CellStrip cell)
        {
            InitializeComponent();
            avaibleOperators = MachineTuring.cellsTable.DistinctBy(i => i.row).ToList();
            if (avaibleOperators.Count == 0)
            {
                return;
            }
            else
            {
                currentCell = cell;
                
                Int32 index = 0;
               
                foreach (Cell c in avaibleOperators)
                {
                    DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                    column.Width = 25;
                    operatorsMenu.Columns.Add(column);
                    operatorsMenu.Columns[index].DefaultCellStyle.NullValue = c.row.ToString();
                    index++;
                }
            }
        }
        private void operatorsMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                currentCell.data = operatorsMenu.Columns[e.ColumnIndex].DefaultCellStyle.NullValue.
                                   ToString().ToCharArray().First<Char>();
            }
            this.Close();
        }
        public static Char getData()
        {
            return currentCell.data;
        }

    }
}
