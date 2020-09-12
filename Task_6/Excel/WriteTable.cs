using Microsoft.Office.Interop.Excel;
using System.Data;

namespace Excel
{
    internal class WriteTable
    {
        private Application _excelApp;
        private Workbook _workBook;
        private Worksheet _workSheet;

        /// <summary>
        /// Write table constructor 
        /// </summary>
        public WriteTable()
        {
            _excelApp = new Application();
            _workBook = _excelApp.Workbooks.Add();
            _workSheet = (Worksheet)_workBook.ActiveSheet;
        }
        /// <summary>
        /// Write dataTable in xlsx file
        /// </summary>
        /// <param name="dataTable">Datatable to write</param>
        /// <param name="path">Path to write</param>
        /// <param name="rowShift">How many rows skip</param>
        /// <param name="columnShift">How many columns skip</param>
        public void Write(System.Data.DataTable dataTable, string path, int rowShift = 1, int columnShift = 1)
        {
            int row = 0;
            int column = 0;

            foreach (DataRow TableRow in dataTable.Rows)
            {
                foreach (var cell in TableRow.ItemArray)
                {
                    _workSheet.Cells[rowShift + row, columnShift + column] = cell.ToString();
                    column++;
                }
                row++;
                column = 0;
            }

            _workBook.Close(true, path);

        }
    }
}