using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Excel
{
    /// <summary>
    /// Sorting enums
    /// </summary>
    public enum OrderBy
    {
        Ascending = XlSortOrder.xlAscending,
        Decending = XlSortOrder.xlDescending,
    }
}
