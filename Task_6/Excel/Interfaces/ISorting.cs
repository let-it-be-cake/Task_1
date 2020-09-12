using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Excel.Interfaces
{
    interface ISorting
    {
        public void Sort(string startCell,
            string endCell,
            int column = 1,
            XlSortOrder order = XlSortOrder.xlAscending);
        public void Sort(int startX,
           int startY,
           int endX,
           int endY,
           int column = 1,
           XlSortOrder order = XlSortOrder.xlAscending);
    }
}
