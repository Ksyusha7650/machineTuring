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
        Int32 index = 1, indexCol = 0, beginIndex, beginStepIndex;
        private List<Char> actions = new List<Char> { '<', '>', '.' };
        private CellStrip cellS = new CellStrip();
        private Cell cellOp = new Cell();
        private bool firstStep = true, lowCount=false;
        private const String path = "../strip.txt";
        private const String path2 = "../prog.txt";



        private void strip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CellStrip cur = cellsStrip[strip.CurrentCell.ColumnIndex];
            ChooseOperators operatorsDiaolg = new ChooseOperators(cur);
            if (cellsTable.Count == 0)
            {
                MessageBoxCar message = new MessageBoxCar("Введите алфавит", 1);
                message.ShowDialog();
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
                strip.Columns[cell.index + 100].DefaultCellStyle.NullValue = cell.data.ToString();
            }
        }

        public MachineTuring()
        {
            InitializeComponent();
            for (Int32 i = -100; i <= 100; i++)
            {
                CellStrip newCell = new CellStrip();
                newCell.index = i;
                newCell.data = '_';
                cellsStrip.Add(newCell);
                DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                column.Name = newCell.index.ToString();
                strip.Columns.Add(column);
                strip.Columns[indexCol].Width = 30;
                strip.Rows[0].Height = 30;
                indexCol++;
            }
            strip.FirstDisplayedScrollingColumnIndex = 85;
            ShowStrip();
            Int32 ind = 0;

            for (Int32 i = 0; i < tableAlgorithms.Columns.Count; i++)
            {
                tableAlgorithms.Columns[i].ContextMenuStrip = contextMenuStripTable;
            }
            tableAlgorithms.Rows.Add("_");
            foreach (DataGridViewColumn column in tableAlgorithms.Columns)
            {
                Cell newCell = new Cell();
                newCell.col = "Q" + (ind).ToString();
                newCell.row = '_';
                ind++;
                cellsTable.Add(newCell);
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
            foreach (DataGridViewRow row in tableAlgorithms.Rows)
                cellsTable.Add(new Cell(text, row.Cells[0].Value.ToString().ToCharArray().First<Char>(), ""));
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
            if (indexCol == 1) return;
            foreach (DataGridViewRow row in tableAlgorithms.Rows)
            {
                int index = cellsTable.FindIndex(x => x.row == row.Cells[0].Value.ToString().ToCharArray().
                First<Char>() && x.col == "Q" + (indexCol-1).ToString());
                cellsTable.RemoveAt(index);
            }
            tableAlgorithms.Columns.RemoveAt(indexCol - 1);
        }

        private void InputToCell(DataGridViewCell cell)
        {
            if (cell.Value != null)
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
                    MessageBoxCar messageBox = new MessageBoxCar("Некорректный ввод", 1);
                    messageBox.ShowDialog();
                    cell.Value = "";
                }
                else
                {
                    Cell c = new Cell();
                    c.data = cell.Value.ToString();
                    c.col = "Q" + cell.ColumnIndex.ToString();
                    c.row = tableAlgorithms.Rows[cell.RowIndex].
                            Cells[0].Value.ToString().ToCharArray().First<Char>();
                    Int32 index = cellsTable.FindIndex(x => x.col == c.col && x.row == c.row);
                    cellsTable[index] = c;
                }
            }
            else
            {
                cell.Value = "";
                Cell c = new Cell();
                c.data = cell.Value.ToString();
                c.col = "Q" + cell.ColumnIndex.ToString();

                c.row = tableAlgorithms.Rows[cell.RowIndex].
                        Cells[0].Value.ToString().ToCharArray().First<Char>();
                Int32 index = cellsTable.FindIndex(x => x.col == c.col && x.row == c.row);
                cellsTable[index] = c;
            }
        }

        private void writeToCell(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in tableAlgorithms.SelectedCells)
            {
                InputToCell(cell);
            }
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        private void goAlgotithm(Int32 index, bool step)
        {
            if (cellsTable != null)
            {
                beginIndex = Int32.Parse(beginAlgorithm.Value.ToString());
                currIndexLabel.Text = beginIndex.ToString();
                if (firstStep)
                {
                    beginStepIndex = beginIndex;
                    firstStep = false;
                }
                cellS = cellsStrip[index + 100];
                Int32 ind = cellsTable.FindIndex(x => x.row == cellS.data && x.col == "Q1");
                if (ind == -1)
                {
                    string output = "Ячейка " + cellOp.col + ":" + cellOp.row + "  не найдена";
                    MessageBoxCar messageBox2 = new MessageBoxCar(output, 1);
                    messageBox2.ShowDialog();
                    return;
                }
                cellOp = cellsTable[ind];
                String data = cellOp.data;
                String tempData = "";
                if (data != null)
                {
                    while (!cellOp.data.Contains("0"))
                    {
                        cellS.data = cellOp.data[0];
                        cellsStrip[cellS.index + 100] = cellS;
                        tempData = cellOp.data;
                        beginStepIndex++;
                        if (step) break;
                        else
                        {
                            GoNext();
                            ShowStrip();
                            data = cellOp.data;
                            if (data == null)
                            {
                                string output = "Ячейка " + cellOp.col + ":" + cellOp.row + "  пустая";
                                MessageBoxCar messageBox2 = new MessageBoxCar(output, 1);
                                messageBox2.ShowDialog();
                                break;
                            }
                        }
                       
                    }
                    data = cellOp.data;
                    if (data != null)
                    {
                        cellS.data = cellOp.data[0];
                        if (cellOp.data.Contains("0"))
                        {
                            firstStep = true;
                            MessageBoxCar messageBox = new MessageBoxCar("Выполнение программы завершено!", 0);
                            messageBox.ShowDialog();
                        }
                    }
                    else cellS.data = tempData[0];
                    if (step) currIndexLabel.Text = beginStepIndex.ToString();
                    cellsStrip[cellS.index + 100] = cellS;
                    currIndexLabel.Text = beginIndex.ToString();
                    ShowStrip();
                }
                else
                {
                    string output = "Ячейка " + cellOp.col + ":" + cellOp.row + "  пустая";
                    MessageBoxCar messageBox = new MessageBoxCar(output, 1);
                    messageBox.ShowDialog();
                }
            }
        }
        private void launch_Click(object sender, EventArgs e)
        {
            goAlgotithm(beginIndex, false);
        }

        private void GoNext()
        {
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
            currIndexLabel.Text = beginIndex.ToString();
            cellS = cellsStrip.Find(x => x.index == beginIndex);
            Char[] array2 = new Char[cellOp.data.Length - 2];
            Array.Copy(cellOp.data.ToCharArray(), 2, array2, 0, array2.Length);
            String indexNextCol = new String(array2);
            cellOp = cellsTable.Find(x => x.row == cellS.data && (x.col.ToString()) == "Q" + indexNextCol);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveStrip_Click(object sender, EventArgs e)
        {
            FileWork.saveStr(path);
        }

        private void loadStr_Click(object sender, EventArgs e)
        {
            FileWork.loadStr(path);
            ShowStrip();
        }

        private void saveAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWork.saveTab(path2);

        }

        private void openProgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FileWork.openTab(path2);
            MessageBoxCar message = new MessageBoxCar("Функция еще находится в разработке", 1);
            message.ShowDialog();
        }

        private void beginAlgorithm_ValueChanged(object sender, EventArgs e)
        {
            beginIndex = Int32.Parse(beginAlgorithm.Value.ToString());
            currIndexLabel.Text = beginIndex.ToString();    
        }


        private void onSteps_Click(object sender, EventArgs e)
        {
            goAlgotithm(beginStepIndex, true);
        }

        public void setTable()
        {
            Int32 amountCols = tableAlgorithms.Columns.Count - 1;
            for (Int32 i = 1; i < amountCols - 1; i++)
            {
                tableAlgorithms.Columns.RemoveAt(i);
            }
            var operators = cellsTable.GroupBy(x => x.row).Select(x => x.First()).ToList();
            foreach (Cell cell in operators)
            {
                tableAlgorithms.Rows.Add(cell.row);
            }
            List<Cell> cells = cellsTable.Where(x => x.col != "Q0" && x.row != '\0').ToList();
            foreach (DataGridViewCell cell in tableAlgorithms.Rows)
            {
                InputToCell(cell);
            }
        }
        private void alphabet_TextChanged(object sender, EventArgs e)
        {
            if (lowCount)
            {
                lowCount = false;
                return;
            }
            String text = alphabet.Text;
            var operators = text.ToList();
            Cell newCell = new Cell();
            if (operators.Count == 0)
            {
                lowCount = true;
                alphabet.Text = "_";
            }
            else if (index > operators.Count - 1)
            {
                tableAlgorithms.Rows.RemoveAt(index - 1);
                index--;
                for (Int32 i = 0; i < cellsTable.Count; i++)
                {
                    if (!(operators.Contains(cellsTable[i].row)))
                    {
                        cellsTable.Remove(cellsTable[i]);
                        i--;
                    }
                }
            }
            else
            {
                Int32 ind = 0;
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
                    if (!tableAlgorithms.Columns.Contains(newCell.row.ToString()))
                    {
                        tableAlgorithms.Rows.Add(newCell.row.ToString());
                        index++;
                    }
                }
            }

        }

    }
}