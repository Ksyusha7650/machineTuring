using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace machineTuring
{
    public partial class MachineTuring : Form
    {
        public static List<Cell> cellsTable = new List<Cell>();
        public static List<CellStrip> cellsStrip = new List<CellStrip>();
        Int32 index = 0, indexCol = 0, beginIndex;
        private List<Char> actions = new List<Char> { '<', '>', '.' };
        private CellStrip cellS = new CellStrip();
        private Cell cellOp = new Cell();




        private void strip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellStrip cur = cellsStrip[strip.CurrentCell.ColumnIndex];
            ChooseOperators operatorsDiaolg = new ChooseOperators(cur);
            if (cellsTable.Count == 0)
            {
                MessageBox.Show("Введите алфавит");
                return;
            }
            operatorsDiaolg.ShowDialog();
            cur.data = ChooseOperators.getData();
            cellsStrip[strip.CurrentCell.ColumnIndex] = cur;

            ShowStrip();
        }

        public void ShowStrip()
        {
            foreach (CellStrip cell in cellsStrip)
            {
                strip.Columns[cell.index + 100].DefaultCellStyle.NullValue = cell.data;
            }
        }

        public MachineTuring()
        {
            InitializeComponent();
            for (Int32 i = -100; i <= 100; i++)
            {
                CellStrip newCell = new CellStrip();
                newCell.index = i;
                cellsStrip.Add(newCell);
                DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                column.Name = newCell.index.ToString();
                strip.Columns.Add(column);
                strip.Columns[indexCol].Width = 30;
                strip.Rows[0].Height = 30;
                indexCol++;
            }
            strip.FirstDisplayedScrollingColumnIndex = 85;

            for (Int32 i = 0; i < tableAlgorithms.Columns.Count; i++)
            {
                tableAlgorithms.Columns[i].ContextMenuStrip = contextMenuStripTable;
            }
            beginAlgorithm.Maximum = 100;
            beginAlgorithm.Minimum = -100;

        }

        private void addCol_Click(object sender, EventArgs e)
        {
            Int32 indexCol = tableAlgorithms.ColumnCount;
            String text = "Q" + (indexCol).ToString();
            tableAlgorithms.Columns.Add(text, text);
            tableAlgorithms.Columns[indexCol].Width = 75;
        }

        private void tableAlgorithms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            beginIndex = Int32.Parse(beginAlgorithm.Value.ToString());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Int32 indexCol = tableAlgorithms.SelectedCells[0].ColumnIndex;
            DataGridViewColumn column = new DataGridViewColumn();
            column.Name = "Q" + (indexCol - 1).ToString();
            column.HeaderText = "Q" + (indexCol - 1).ToString();
            column.CellTemplate = new DataGridViewTextBoxCell();
            tableAlgorithms.Columns.Insert(indexCol - 1, column);
            tableAlgorithms.Columns[indexCol - 1].ContextMenuStrip = contextMenuStripTable;
            foreach (DataGridViewColumn col in tableAlgorithms.Columns)
            {
                if ((col.Index <= indexCol) && (col.Index > 0))
                {
                    col.Name = "Q" + (col.Index - 1).ToString();
                    col.HeaderText = "Q" + (col.Index - 1).ToString();
                }
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Int32 indexCol = tableAlgorithms.SelectedCells[0].ColumnIndex;
            DataGridViewColumn column = new DataGridViewColumn();
            column.Name = "Q" + (indexCol + 1).ToString();
            column.HeaderText = "Q" + (indexCol + 1).ToString();
            column.CellTemplate = new DataGridViewTextBoxCell();
            tableAlgorithms.Columns.Insert(indexCol + 1, column);
            tableAlgorithms.Columns[indexCol + 1].ContextMenuStrip = contextMenuStripTable;
            foreach (DataGridViewColumn col in tableAlgorithms.Columns)
            {
                if ((col.Index >= indexCol))
                {
                    col.Name = "Q" + (col.Index + 1).ToString();
                    col.HeaderText = "Q" + (col.Index + 1).ToString();

                }
            }
        }

        private void delCol_Click(object sender, EventArgs e)
        {
            Int32 indexCol = tableAlgorithms.ColumnCount;
            tableAlgorithms.Columns.RemoveAt(indexCol - 1);
        }

        private void writeToCell(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in tableAlgorithms.SelectedCells)
            {
                String val = cell.Value.ToString();
                Char[] array = val.ToCharArray();
                bool check = false;
                if (array.Length >= 3)
                {
                    foreach (Cell cell1 in cellsTable)
                    {
                        if (cell1.row.ToString().ToCharArray().First<Char>() == array[0])
                        {
                            check = true;
                        }
                    }
                    if (check)
                    {
                        check = false;
                        if (actions.Contains(array[1])) check = true;
                        if (check)
                        {
                            check = false;
                            foreach (DataGridViewColumn col in tableAlgorithms.Columns)
                            {
                                String headerCol = col.Name.Remove(0, 1);
                                Char[] array2 = new Char[array.Length - 2];
                                Array.Copy(array, 2, array2, 0, array2.Length); 
                                String indexNextCol = new String(array2);
                                if (headerCol == indexNextCol)
                                {
                                    check = true;
                                }
                                else if (indexNextCol == "0")
                                {
                                    check = true;
                                }
                            }
                        }
                    }
                }
                else check = false;
                if (!check)
                {
                    MessageBox.Show("Неправильный ввод :с");
                    cell.Value = "";
                }
                else
                {
                    Cell c = new Cell();
                    c.data = cell.Value.ToString();
                    c.col = "Q" + cell.ColumnIndex.ToString();
                    
                    c.row = tableAlgorithms.Rows[cell.RowIndex].
                            Cells[0].Value.ToString().ToCharArray().First<Char>(); //Значение у строки взять
                    Int32 index = cellsTable.FindIndex(x => x.col == c.col && x.row == c.row);
                    cellsTable[index] = c;
                }
            }
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void launch_Click(object sender, EventArgs e)
        {
           if (cellsTable != null)
            {
                cellS = cellsStrip[beginIndex + 100];
                cellOp = cellsTable.Find(x => x.row == cellS.data && x.col == "Q1"); ///COL
                while (!cellOp.data.Contains("0"))
                {
                    GoNext(cellS, cellOp);
                }
            }
        }

        private void GoNext(CellStrip cellS, Cell cellT)
        {
            Cell tempCell = cellT;
            switch ((Char)cellOp.data[1])
            {
                case '<':
                    {
                        beginIndex--;
                        break;
                    }
                case '>':
                    {
                        beginIndex++;
                        break;
                    }
                case '.':
                    {
                        break;
                    }
            }
            cellS = cellsStrip.Find(x => x.data == cellT.data.First<Char>() && x.index == beginIndex);
            Char[] array2 = new Char[cellT.data.Length - 2];
            Array.Copy(cellT.data.ToCharArray(), 2, array2, 0, array2.Length);
            String indexNextCol = new String(array2);
            cellT = cellsTable.Find(x => x.row == cellS.data && ("Q" + x.col.ToString()) == indexNextCol);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveStrip_Click(object sender, EventArgs e)
        {
            FileWork.saveStr();
        }

        private void loadStr_Click(object sender, EventArgs e)
        {
            FileWork.loadStr();
            ShowStrip();
        }

        private void beginAlgorithm_ValueChanged(object sender, EventArgs e)
        {
            beginIndex = Int32.Parse(beginAlgorithm.Value.ToString());
        }

        private void alphabet_TextChanged(object sender, EventArgs e)
        {
            String text = alphabet.Text;
            var operators = text.ToCharArray();
            Cell newCell = new Cell();
            if (index > operators.Length - 1)
            {
                for (Int32 i = 0; i < cellsTable.Count; i++)
                {
                    if (!(operators.Contains(cellsTable[i].row)))
                    {
                        tableAlgorithms.Rows.RemoveAt(i);
                        cellsTable.Remove(cellsTable[i]);
                        index--;
                    }
                }
            }
            else
            {
                int ind = 0;
                Cell temp = cellsTable.Find(x => x.row == newCell.row);
                foreach (DataGridViewColumn column in tableAlgorithms.Columns)
                {
                    newCell.row = operators[index];
                    newCell.col = "Q" + (ind).ToString();
                    ind++;
                    cellsTable.Add(newCell);
                }
                if (temp.col != null) return;
                else
                {
                    if (!(tableAlgorithms.Columns.Contains(newCell.row.ToString())))
                    {
                        tableAlgorithms.Rows.Add(newCell.row.ToString());
                        index++;
                    }
                }
            }
           
        }

    }
}
