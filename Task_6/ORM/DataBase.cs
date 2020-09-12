using ORM.Tables;
using System.Collections.Generic;

namespace ORM
{
    /// <summary>
    /// Database class
    /// </summary>
    public class DataBase
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Gradebook> Gradebook { get; set; }
        public DbSet<CreditList> CreditList { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Theme> Theme { get; set; }


        private DataBase(string connection)
        {
            Student = new DbSet<Student>(connection);
            Credit = new DbSet<Credit>(connection);
            Exam = new DbSet<Exam>(connection);
            Gradebook = new DbSet<Gradebook>(connection);
            CreditList = new DbSet<CreditList>(connection);
            Group = new DbSet<Group>(connection);
            Session = new DbSet<Session>(connection);
            Subject = new DbSet<Subject>(connection);
            Theme = new DbSet<Theme>(connection);
        }

        private static DataBase _instance;

        /// <summary>
        /// Create one instance of database
        /// </summary>
        /// <param name="connection">Connection string for database</param>
        /// <returns>Instance of database</returns>
        public static DataBase Get(string connection)
        {
            _instance = _instance == null ? new DataBase(connection) : _instance;
            return _instance;
        }
    }
}