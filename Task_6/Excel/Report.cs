using Excel;
using Microsoft.Office.Interop.Excel;
using ORM;

namespace Exc
{
    public class ReportCreater
    {
        private CreateTable _tableCreater;
        private Sorting _sorting;
        private DataBase _data;

        public ReportCreater(DataBase data)
        {
            _data = data;
            _tableCreater = new CreateTable();
        }

        public void MarkReport( string path,
            int? sortingColumn = null,
            OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.MarkTable(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;

            Sorting(dataTable, path, sortingColumn.Value, order);
        }

        public void DismissalReport( string path,
            int? sortingColumn = null, OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.DismissalTable(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;
            Sorting(dataTable, path, sortingColumn.Value, order);
        }

        public void SessionsReport( string path,
            int? sortingColumn = null, OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.SessionsTable(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;
            Sorting(dataTable, path, sortingColumn.Value, order);
        }

        private void Sorting(System.Data.DataTable table,
            string path,
            int sortingColumn,
            OrderBy order = OrderBy.Ascending)
        {
            var columns = table.Columns.Count;
            var rows = table.Rows.Count;

            _sorting = new Sorting(path);
            _sorting.Sort(1, 1, columns, rows, sortingColumn, (XlSortOrder)order);
        }
                            }
}