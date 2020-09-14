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
        private const string allSessionsPath = @"AllSessions.txt";
        private const string oneSessionsPath = @"OneSessions.txt";

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


        [TestMethod]
        public void ReportOneSessionsTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.OneSessionReport(oneSessionsPath);
        }

        [TestMethod]
        public void ReportOneSessionsTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.OneSessionReport(oneSessionsPath, 1, Excel.OrderBy.Decending);
        }

        [TestMethod]
        public void ReportAllSessionsTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.AllSessionsReport(allSessionsPath);
        }

        [TestMethod]
        public void ReportAllSessionsTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.AllSessionsReport(allSessionsPath, 1, Excel.OrderBy.Decending);
        }
    }
}