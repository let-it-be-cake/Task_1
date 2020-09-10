using Microsoft.Office.Interop.Excel;
using System.Data;

namespace Excel
{
    internal class WriteTable
    {
        private Application _excelApp;
        private Workbook _workBook;
        private Worksheet _workSheet;

        public WriteTable()
        {
            _excelApp = new Application();
            _workBook = _excelApp.Workbooks.Add();
            _workSheet = (Worksheet)_workBook.ActiveSheet;
        }
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