using Excel.Interfaces;
using Orm;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataTable = System.Data.DataTable;

namespace Excel
{
    /// <summary>
    /// Internal class to create table
    /// </summary>
    internal class CreateTable : ICreate
    {
        /// <summary>
        ///  Generating a table with mark
        /// </summary>
        /// <param name="data">Database for table generation</param>
        /// <returns></returns>
        public DataTable Mark(DataBase data)
        {
            DataTable dataTable = new DataTable();
            var row = dataTable.NewRow();

            for (int i = 0; i < 5; i++)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            row[0] = "Session";
            row[1] = "Group";
            row[2] = "Min Mark";
            row[3] = "Average mark";
            row[4] = "Max Mark";

            dataTable.Rows.Add(row);

            data.Session.Load();
            data.Group.Load();
            data.Gradebook.Load();

            var sessions = data.Session.Collection;
            var group = data.Group.Collection;
            var gradebook = data.Gradebook.Collection;

            foreach (var session in sessions)
            {
                var sessionId = session.Id.ToString();
                var groupName = group.First(o => o.Id == session.GroupId).Name;

                IEnumerable<int> sessionsMark = gradebook
                    .Where(o => o.SessionId == session.Id)
                    .Select(o => o.Mark);

                sessionsMark = sessionsMark.Count() != 0 ? sessionsMark : new int[] { 0 };

                int maxMark = sessionsMark.Max();
                double averageMark = sessionsMark.Average();
                int minMark = sessionsMark.Min();

                row = dataTable.NewRow();

                row[0] = sessionId;
                row[1] = groupName;
                row[2] = minMark;
                row[3] = averageMark;
                row[4] = maxMark;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /// <summary>
        /// Generating a table with dismissal students
        /// </summary>
        /// <param name="data">Database for table generation</param>
        /// <returns></returns>
        public DataTable Dismissal(DataBase data)
        {
            DataTable dataTable = new DataTable();

            var row = dataTable.NewRow();

            for (int i = 0; i < 2; i++)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            row[0] = "Group";
            row[1] = "Student";

            dataTable.Rows.Add(row);

            data.Student.Load();
            data.Group.Load();
            data.Gradebook.Load();
            data.CreditList.Load();

            var students = data.Student.Collection;
            var groups = data.Group.Collection;
            var gradebooks = data.Gradebook.Collection;
            var creditLists = data.CreditList.Collection;

            foreach (var group in groups)
            {
                var groupStudents = students.Where(o => o.GroupId == group.Id);
                foreach (var student in groupStudents)
                {
                    if (creditLists
                            .Any(o => o.StudentId == student.Id
                                && o.Passed == false)

                        || gradebooks
                            .Where(o => o.StudentId == student.Id
                                && o.Mark < 4).Count() >= 3)
                    {
                        row = dataTable.NewRow();

                        row[0] = group.Name;
                        row[1] = student.Name;

                        dataTable.Rows.Add(row);
                    }
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Generating a table with sessions
        /// </summary>
        /// <param name="data">Database for table generation</param>
        /// <returns></returns>
        public DataTable Sessions(DataBase data)
        {
            DataTable dataTable = new DataTable();

            var row = dataTable.NewRow();

            for (int i = 0; i < 5; i++)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            row[0] = "Session";
            row[1] = "Group";
            row[2] = "Student";
            row[3] = "Subject";
            row[4] = "Mark";

            dataTable.Rows.Add(row);

            data.Session.Load();
            data.Group.Load();
            data.Gradebook.Load();
            data.Student.Load();
            data.Subject.Load();

            var sessions = data.Session.Collection;
            var groups = data.Group.Collection;
            var gradebooks = data.Gradebook.Collection;
            var students = data.Student.Collection;
            var subjects = data.Subject.Collection;

            foreach (var session in sessions)
            {
                var group = groups.FirstOrDefault(o => o.Id == session.GroupId);
                var groupStudents = students.Where(o => o.GroupId == group.Id);
                foreach (var student in groupStudents)
                {
                    var studentGradebook = gradebooks.Where(o => o.StudentId == student.Id);
                    foreach (var gradebook in studentGradebook)
                    {
                        var subject = subjects.FirstOrDefault(o => o.Id == gradebook.SubjectId);

                        row = dataTable.NewRow();

                        row[0] = session.Id;
                        row[1] = group.Name;
                        row[2] = student.Name + " " + student.LastName;
                        row[3] = subject.Name;
                        row[4] = gradebook.Mark;

                        dataTable.Rows.Add(row);
                    }
                }
            }
            return dataTable;
        }

        public DataTable OneSession(DataBase data)
        {
            DataTable dataTable = new DataTable();

            var row = dataTable.NewRow();

            for (int i = 0; i < 5; i++)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            row[0] = "Speciality";
            row[1] = "Average Mark";
            row[2] = "Examiner Name";
            row[3] = "Average Mark";

            dataTable.Rows.Add(row);

            row = dataTable.NewRow();

            data.Session.Load();
            data.Examiner.Load();

            var sessions = data.Session.Collection;
            var examiners = data.Examiner.Collection;

            foreach (var session in sessions)
            {
                int summingMark = 0;
                int numberOfMarks = 0;

                row[0] = session.Id;

                session
                    .Group
                    .Student
                    .ToList()
                    .ForEach(student =>
                        {
                            var markCollection = student
                            .Gradebook
                            .Select(o => o.Mark);
                            summingMark += markCollection.Sum();
                            numberOfMarks += markCollection.Count();
                        });

                if (numberOfMarks == 0)
                    row[1] = 0;
                else
                    row[1] = summingMark / numberOfMarks;

                session
                    .Gradebook
                    .ToList()
                    .ForEach(gradebook => {
                        row[2] = gradebook?
                            .Examiner
                            .Name;

                        row[3] = gradebook
                            .Examiner
                            .Gradebook
                            .Select(o => o.Mark)
                            .Average();

                        dataTable.Rows.Add(row);

                        row = dataTable.NewRow();
                });

            }
            return dataTable;
        }
        public DataTable AllSessions(DataBase data)
        {
            DataTable dataTable = new DataTable();

            var row = dataTable.NewRow();

            for (int i = 0; i < 5; i++)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            row[0] = "Session";
            row[1] = "Subject";
            row[2] = "Year";
            row[3] = "Average Mark";

            dataTable.Rows.Add(row);

            row = dataTable.NewRow();

            data.Exam.Load();

            var exams = data.Exam.Collection;

            foreach (var exam in exams)
            {
                row[0] = exam.Session.Id;
                row[1] = exam.Subject.Name;
                row[2] = exam.Session.StartDate.Year;
                row[3] = exam.Session.Gradebook.Average(o => o.Mark);
            }
            return dataTable;
        }
    }
}