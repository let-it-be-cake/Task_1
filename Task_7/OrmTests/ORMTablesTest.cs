using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orm;
using System;
using System.Linq;

namespace ORMTest
{
    [TestClass]
    public class ORMTablesTest
    {
        private const string connection = @"Data Source=ADMIN-PC;Initial Catalog=Colledge1;Integrated Security=True";

        [TestMethod]
        public void AddCreditValueInDataBase()
        {
            //arrange
            var expected = new Credit()
            {
                Id = 100,
                DateOfCredit = new DateTime(2000, 1, 1),
                GroupId = 3,
                SubjectId = 3,
                ExaminerId = 1,
            };
            DataBase db = DataBase.Get(connection);
            db.Credit.Load();
            //act
            db.Credit.Add(expected);
            var actual = db.Credit.Collection.Last();
            db.Credit.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddCreditListValueInDataBase()
        {
            //arrange
            var expected = new CreditList()
            {
                Id = 100,
                Passed = true,
                SessionId = 9,
                StudentId = 40,
                SubjectId = 3,
            };
            DataBase db = DataBase.Get(connection);
            db.CreditList.Load();
            //act
            db.CreditList.Add(expected);
            var actual = db.CreditList.Collection.Last();
            db.CreditList.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddExamListValueInDataBase()
        {
            //arrange
            var expected = new Exam()
            {
                Id = 100,
                DateOfExam = new DateTime(2000, 1, 1),
                GroupId = 3,
                SubjectId = 3,
                ExaminerId = 1,
            };
            DataBase db = DataBase.Get(connection);
            db.Exam.Load();
            //act
            db.Exam.Add(expected);
            var actual = db.Exam.Collection.Last();
            db.Exam.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddGradebookListValueInDataBase()
        {
            //arrange
            var expected = new Gradebook()
            {
                Id = 100,
                Mark = 10,
                SessionId = 9,
                StudentId = 40,
                SubjectId = 3,
                ExaminerId = 1,
            };
            DataBase db = DataBase.Get(connection);
            db.Gradebook.Load();
            //act
            db.Gradebook.Add(expected);
            var actual = db.Gradebook.Collection.Last();
            db.Gradebook.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddGroupListValueInDataBase()
        {
            //arrange
            var expected = new Group()
            {
                Id = 100,
                Name = "Test",
            };
            DataBase db = DataBase.Get(connection);
            db.Group.Load();
            //act
            db.Group.Add(expected);
            var actual = db.Group.Collection.Last();
            db.Group.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSessionListValueInDataBase()
        {
            //arrange
            var expected = new Session()
            {
                Id = 100,
                EndDate = new DateTime(2000, 2, 2),
                StartDate = new DateTime(2000, 1, 1),
                GroupId = 3,
            };
            DataBase db = DataBase.Get(connection);
            db.Session.Load();
            //act
            db.Session.Add(expected);
            var actual = db.Session.Collection.Last();
            db.Session.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddStudentListValueInDataBase()
        {
            //arrange
            var expected = new Student()
            {
                Id = 100,
                DateOfBirth = new DateTime(2000, 1, 1),
                LastName = "Test",
                Name = "Test",
                GroupId = 3,
            };
            DataBase db = DataBase.Get(connection);
            db.Student.Load();
            //act
            db.Student.Add(expected);
            var actual = db.Student.Collection.Last();
            db.Student.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSubjectListValueInDataBase()
        {
            //arrange
            var expected = new Subject()
            {
                Id = 100,
                Name = "Test"
            };
            DataBase db = DataBase.Get(connection);
            db.Subject.Load();
            //act
            db.Subject.Add(expected);
            var actual = db.Subject.Collection.Last();
            db.Subject.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddThemeListValueInDataBase()
        {
            //arrange
            var expected = new Theme()
            {
                Id = 100,
                Name = "Test",
                SubjectId = 3
            };
            DataBase db = DataBase.Get(connection);
            db.Theme.Load();
            //act
            db.Theme.Add(expected);
            var actual = db.Theme.Collection.Last();
            db.Theme.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddExaminerValueInDataVase()
        {
            //arrange
            var expected = new Examiner()
            {
                Id = 100,
                Name = "Test",
                LastName = "Test",
            };
            DataBase db = DataBase.Get(connection);
            db.Examiner.Load();
            //act
            db.Examiner.Add(expected);
            var actual = db.Examiner.Collection.Last();
            db.Examiner.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSpecialityValueInDataVase()
        {
            //arrange
            var expected = new Specialty()
            {
                Id = 100,
                Name = "Test",
            };
            DataBase db = DataBase.Get(connection);
            db.Specialty.Load();
            //act
            db.Specialty.Add(expected);
            var actual = db.Specialty.Collection.Last();
            db.Specialty.Delete(expected);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}