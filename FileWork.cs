using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security;

namespace machineTuring
{
    public struct FileWork
    {

        public static void saveStr(String path)
        {
            List<String> line = new List<String>();
            foreach (CellStrip c in MachineTuring.cellsStrip)
            {
                line.Add(c.data.ToString());
            }
            File.Delete(path);
            File.AppendAllLines(path, line);
        }

        public static void loadStr(String path)
        {
            List<String> line = File.ReadAllLines(path).ToList();
            for (Int32 i = 0; i < line.Count; i++)
            {
                CellStrip c = MachineTuring.cellsStrip[i];
                c.data = line[i].ToCharArray().First<Char>();
                MachineTuring.cellsStrip[i] = c;
            }
        }
        public static void saveTab(String path)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Текстовые файлы txt|*.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                if (path != "")
                {
                    File.Delete(path);
                    List<String> line = new List<String>();
                    foreach (Cell c in MachineTuring.cellsTable)
                    {
                        if (c.data == null)
                            line.Add(c.row.ToString() + "," + c.col.ToString() + ":null");
                        else
                            line.Add(c.row.ToString() + "," + c.col.ToString() + ":" + c.data.ToString());
                    }
                    File.AppendAllLines(path, line);
                }
            }
        }

        public static void openTab(String path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Текстовые файлы txt|*.txt",
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                try
                {
                    List<String> line = File.ReadAllLines(path).ToList();
                    Int32 index;
                    for (index = 1; index < line.Count; index++)
                    {
                        Char[] symbols = line[index].ToCharArray();
                        String[] column = line[index].Split(',');
                        String tempStr = column[1];
                        Int32 count = tempStr.IndexOf(':');
                        String resColumn = tempStr.Substring(0, count);
                        String data = tempStr.Substring(count + 1);
                        Int32 cellIndex = MachineTuring.cellsTable.FindIndex(x => x.col == resColumn);
                        Cell cell = new Cell();
                        cell.data = data;
                        cell.row = symbols[0];
                        cell.col = resColumn;
                        MachineTuring.cellsTable[cellIndex] = cell;
                        index++;
                    }
                    MachineTuring m = new MachineTuring();
                    m.setTable();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show(ex.Message + " " + ex.StackTrace);
                }
            }
        }
       
    }
}
