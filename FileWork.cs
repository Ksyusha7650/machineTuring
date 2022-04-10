using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace machineTuring
{
    public struct FileWork
    {
        private const String path = "../strip.txt";
        private const String path2 = "../alph.txt";
        public static void saveStr()
        { 
            List<String> line = new List<String>();
            foreach(CellStrip c in MachineTuring.cellsStrip)
            {
                line.Add(c.data.ToString());
            }
            File.Delete(path);
            File.AppendAllLines(path, line);
        }

/*        private static void saveAlph()
        {
            List<String> line = new List<String>();
            foreach (Cell c in MachineTuring.cellsTable)
            {
                line.Add(c.row.ToString());
            }
            File.Delete(path2);
            File.AppendAllLines(path2, line);
        }*/
        public static void loadStr()
        {
            List<String> line = File.ReadAllLines(path).ToList();
            for (Int32 i = 0; i < line.Count; i++)
            {
                CellStrip c = MachineTuring.cellsStrip[i];
                c.data = line[i].ToCharArray().First<Char>();
                MachineTuring.cellsStrip[i] = c;
            }
        }

    }
}
