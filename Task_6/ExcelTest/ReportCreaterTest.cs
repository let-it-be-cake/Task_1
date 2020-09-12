using Exc;
using ORM;
using Xunit;

namespace ExcelTest
{
    /// <summary>
    /// Testing report creater
    /// </summary>
    public class ReportCreaterTest
    {
        private const string connection = @"Data Source=ADMIN-PC;Initial Catalog=Colledge;Integrated Security=True";
        private const string markPath = @"Mark.txt";
        private const string dismissalPath = @"Dismissal.txt";
        private const string sessionsPath = @"Sessions.txt";
        [Fact]
        public void ReportMarkTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(markPath);
        }
        [Fact]
        public void ReportMarkTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(markPath, 1, Excel.OrderBy.Decending);
        }

        [Fact]
        public void ReportDismissalTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(dismissalPath);
        }
        [Fact]
        public void ReportDismissalTestWithSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(dismissalPath, 1, Excel.OrderBy.Decending);
        }

        [Fact]
        public void ReportSessionsTestWithoutSorting()
        {
            // arrange
            var db = DataBase.Get(connection);
            // act
            var report = new ReportCreater(db);
            report.MarkReport(sessionsPath);
        }
        [Fact]
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