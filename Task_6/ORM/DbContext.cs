using System.Data.SqlClient;

namespace ORM
{
    public class DbContext
    {
        public SqlConnection Connection { get; set; } = new SqlConnection();

        public DbContext(string connection)
        {
            Connection.ConnectionString = connection;
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}