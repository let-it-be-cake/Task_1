using Exc;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orm;

namespace ExcelTest
{
    /// <summary>
    /// Testing report creater
    /// </summary>

    [TestClass]
    public class ReportCreaterTest
    {
        private const string connection = @"Data Source=ADMIN-PC;Initial Catalog=Colledge1;Integrated Security=True";
        private const string markPath = @"Mark.txt";
        private const string dismissalPath = @"Dismissal.txt";
        private const string sessionsPath = @"Sessions.txt";

        [TestMethod]
        public void ReportMarkTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(markPath);
        }

        [TestMethod]
        public void ReportMarkTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(markPath, 1, Excel.OrderBy.Decending);
        }

        [TestMethod]
        public void ReportDismissalTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(dismissalPath);
        }

        [TestMethod]
        public void ReportDismissalTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(dismissalPath, 1, Excel.OrderBy.Decending);
        }

        [TestMethod]
        public void ReportSessionsTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(sessionsPath);
        }

        [TestMethod]
        public void ReportSessionsTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(sessionsPath, 1, Excel.OrderBy.Decending);
        }
    }
}