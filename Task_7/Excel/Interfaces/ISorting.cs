using Microsoft.Office.Interop.Excel;

namespace Excel.Interfaces
{
    internal interface ISorting
    {
        void Sort(string startCell,
            string endCell,
            int column = 1,
            XlSortOrder order = XlSortOrder.xlAscending);

        void Sort(int startX,
           int startY,
           int endX,
           int endY,
           int column = 1,
           XlSortOrder order = XlSortOrder.xlAscending);
    }
}