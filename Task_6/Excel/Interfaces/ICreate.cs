using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Excel.Interfaces
{
    interface ICreate
    {
        public DataTable Mark(DataBase data);
        public DataTable Dismissal(DataBase data);
        public DataTable Sessions(DataBase data);
    }
}
