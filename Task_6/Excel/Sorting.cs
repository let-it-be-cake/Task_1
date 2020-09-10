using Microsoft.Office.Interop.Excel;
using System;

namespace Excel
{
    internal class Sorting
    {
        static private Application _excelApp;
        static private Workbook _workBook;
        static private Worksheet _workSheet;

        public Sorting(string path)
        {
            _excelApp = new Application();
            _workBook = _excelApp.Workbooks.Open(path);
            _workSheet = (Worksheet)_workBook.ActiveSheet;
        }

        public void Sort(int startX,
            int startY,
            int endX,
            int endY,
            int column = 1,
            XlSortOrder order = XlSortOrder.xlAscending)
        {
            var ran = _workSheet.Range[
                _workSheet.Cells[startY, startX],
                _workSheet.Cells[endY, endX]
                ];
            Sort(ran, column, order);
        }

        public void Sort(string startCell,
            string endCell,
            int column = 1,
            XlSortOrder order = XlSortOrder.xlAscending)
        {
            var ran = _workSheet.Range[startCell, endCell];
            Sort(ran, column, order);
        }

        private void Sort(Microsoft.Office.Interop.Excel.Range range,
            int collumn,
            XlSortOrder order)
        {
            range.Sort(range.Columns[collumn, Type.Missing], order,
                null, Type.Missing, XlSortOrder.xlAscending,
                Type.Missing, XlSortOrder.xlAscending,
                XlYesNoGuess.xlYes, Type.Missing, Type.Missing,
                XlSortOrientation.xlSortColumns);

            _workBook.Close();
            _excelApp.Quit();
        }
    }
}