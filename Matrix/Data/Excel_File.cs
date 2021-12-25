using Matrix.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Matrix
{
    public class Excel_File : Data_File, IReadMatrix
    {
        public Excel_File(string file)
            :base(file)
        {
        }

        public int[,] Read()
        {
            int[,] matrix = new int[7, 7];
            Microsoft.Office.Interop.Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(_file, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            string[,] list = new string[lastCell.Column, lastCell.Row];
            for (int i = 0; i < lastCell.Column; i++)
                for (int j = 0; j < lastCell.Row; j++)
                    list[i, j] = ObjWorkSheet.Cells[j + 1, i + 1].Text.ToString();
            ObjWorkBook.Close(false, Type.Missing, Type.Missing);
            ObjWorkExcel.Quit();
            GC.Collect();

            for (int i = 0; i < list.GetLength(1); i++)
            {
                for (int j = 0; j < list.GetLength(0); j++)
                {
                    _data[j, i] = Convert.ToInt32(list[j, i]);
                }
            }

            return _data;
        }
    }
}
