using Excel.Interfaces;
using Microsoft.Office.Interop.Excel;
using System;

namespace Excel
{
    internal class Sorting : ISorting
    {
        static private Application _excelApp;
        static private Workbook _workBook;
        static private Worksheet _workSheet;

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="path">Path to sorting file</param>
        public Sorting(string path)
        {
            _excelApp = new Application();
            _workBook = _excelApp.Workbooks.Open(path);
            _workSheet = (Worksheet)_workBook.ActiveSheet;
        }

        /// <summary>
        /// Sort xlsx file
        /// </summary>
        /// <param name="startX">Left top x axis</param>
        /// <param name="startY">Left top y axis</param>
        /// <param name="endX">Right bottom x axis</param>
        /// <param name="endY">Right bottom y axis</param>
        /// <param name="column">Sorting column</param>
        /// <param name="order">How order</param>
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

        /// <summary>
        /// Sort xlsx file
        /// </summary>
        /// <param name="startCell">Start cell to sort</param>
        /// <param name="endCell">End cell to sort</param>
        /// <param name="column">Sorting column</param>
        /// <param name="order">How order</param>
        public void Sort(string startCell,
            string endCell,
            int column = 1,
            XlSortOrder order = XlSortOrder.xlAscending)
        {
            var ran = _workSheet.Range[startCell, endCell];
            Sort(ran, column, order);
        }

        /// <summary>
        /// Private sorting class
        /// </summary>
        /// <param name="range">Sorting range</param>
        /// <param name="column">Sorting column</param>
        /// <param name="order">How order</param>
        private void Sort(Microsoft.Office.Interop.Excel.Range range,
            int collumn,
            XlSortOrder order)
        {
            range.Sort(range.Columns[collumn, Type.Missing],
                order,
                Orientation:XlSortOrientation.xlSortColumns);
            //range.Sort(range.Columns[collumn, Type.Missing], order,
            //    null, Type.Missing, XlSortOrder.xlAscending,
            //    Type.Missing, XlSortOrder.xlAscending,
            //    XlYesNoGuess.xlYes, Type.Missing, Type.Missing,
            //    XlSortOrientation.xlSortColumns);

            _workBook.Close();
            _excelApp.Quit();
        }
    }
}