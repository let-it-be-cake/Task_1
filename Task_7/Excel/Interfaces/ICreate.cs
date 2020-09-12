using Orm;
using System.Data;

namespace Excel.Interfaces
{
    internal interface ICreate
    {
        DataTable Mark(DataBase data);

        DataTable Dismissal(DataBase data);

        DataTable Sessions(DataBase data);
    }
}