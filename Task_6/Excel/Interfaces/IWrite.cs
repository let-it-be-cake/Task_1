using Microsoft.Office.Interop.Excel;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Excel.Interfaces
{
    internal interface IWrite
    {
        public void Write(System.Data.DataTable dataTable,
            string path,
            int rowShift = 1,
            int columnShift = 1);
    }
}
