using System.Data.SqlClient;

namespace ORM
{
    /// <summary>
    /// Class for connecting to the database
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// Connection class
        /// </summary>
        public SqlConnection Connection { get; set; } = new SqlConnection();

        /// <summary>
        /// Create connection
        /// </summary>
        /// <param name="connection"></param>
        public DbContext(string connection)
        {
            Connection.ConnectionString = connection;
        }

        /// <summary>
        /// Open connection
        /// </summary>
        public void Open()
        {
            Connection.Open();
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }
    }
}