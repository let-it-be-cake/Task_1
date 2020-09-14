using Excel;
using Excel.Interfaces;
using Microsoft.Office.Interop.Excel;
using Orm;

namespace Exc
{
    public class ReportCreater
    {
        private ICreate _tableCreater;
        private ISorting _sorting;
        private DataBase _data;

        /// <summary>
        /// Create xlsx report
        /// Warning, need excel 2019
        /// </summary>
        /// <param name="data">Database for report creation</param>
        public ReportCreater(DataBase data)
        {
            _data = data;
            _tableCreater = new CreateTable();
        }

        /// <summary>
        /// Create mark report
        /// </summary>
        /// <param name="path">Path to save xlsx file</param>
        /// <param name="sortingColumn">Column to sorting data</param>
        /// <param name="order">How order data</param>
        public void MarkReport(string path,
            int? sortingColumn = null,
            OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.Mark(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;

            Sorting(dataTable, path, sortingColumn.Value, order);
        }

        /// <summary>
        /// Create dismissal report
        /// </summary>
        /// <param name="path">Path to save xlsx file</param>
        /// <param name="sortingColumn">Column to sorting data</param>
        /// <param name="order">How order data</param>
        public void DismissalReport( string path,
            int? sortingColumn = null, OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.Dismissal(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;
            Sorting(dataTable, path, sortingColumn.Value, order);
        }

        /// <summary>
        /// Create sessions report
        /// </summary>
        /// <param name="path">Path to save xlsx file</param>
        /// <param name="sortingColumn">Column to sorting data</param>
        /// <param name="order">How order data</param>
        public void SessionsReport( string path,
            int? sortingColumn = null, OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.Sessions(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;
            Sorting(dataTable, path, sortingColumn.Value, order);
        }
        /// <summary>
        /// Creating a report for a single session
        /// </summary>
        /// <param name="path">Path to save xlsx file</param>
        /// <param name="sortingColumn">Column to sorting data</param>
        /// <param name="order">How order data</param>
        public void OneSessionReport(string path,
            int? sortingColumn = null, OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.OneSession(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);

            if (sortingColumn == null) return;
            Sorting(dataTable, path, sortingColumn.Value, order);
        }
        /// <summary>
        /// Creating a report for all sessions
        /// </summary>
        /// <param name="path">Path to save xlsx file</param>
        /// <param name="sortingColumn">Column to sorting data</param>
        /// <param name="order">How order data</param>
        public void AllSessionsReport(string path,
            int? sortingColumn = null, OrderBy order = OrderBy.Ascending)
        {
            var dataTable = _tableCreater.AllSessions(_data);

            var writeTable = new WriteTable();

            writeTable.Write(dataTable, path);
            
            if (sortingColumn == null) return;
            Sorting(dataTable, path, sortingColumn.Value, order);

        }
        /// <summary>
        /// Sorting xlsx file
        /// </summary>
        /// <param name="table">Table to get sizes</param>
        /// <param name="path">Path to sort xlsx file</param>
        /// <param name="sortingColumn">The sorted column</param>
        /// <param name="order">How order data</param>
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