using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Orm.FabricMethodBasicMethod.Realisations
{
    /// <summary>
    /// Basic method to work with database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BasicMethods<T> : AbstractBasicMethods<T> where T : class, new()
    {
        private string _table;

        private List<PropertyInfo> _properties;

        public BasicMethods()
        {
            _properties = new List<PropertyInfo>(typeof(T).GetProperties());
            Table = typeof(T).Name;
        }

        /// <summary>
        /// Set connection
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// Set table
        /// </summary>
        public string Table
        {
            get => _table; set
            {
                if (value.Contains("]") || value.Contains("[") || value.Contains(" "))
                    throw new ArgumentException("The incoming argument" +
                        "cannot contain square brackets or spaces.");
                _table = " [" + value + "] ";
            }
        }

        /// <summary>
        /// Create new object in database
        /// </summary>
        /// <param name="obj"></param>
        public override void Create(T obj)
        {
            string preInsert = @"SET IDENTITY_INSERT " + Table + " ON; INSERT INTO " + Table + " (";

            foreach (var property in _properties)
            {
                preInsert += property.Name + ",";
            }
            preInsert = preInsert.Remove(preInsert.Length - 1);

            preInsert += ")";

            string insert = @"VALUES " + "(";

            foreach (var property in _properties)
            {
                insert += "@" + property.Name + "Value ,";
            }
            insert = insert.Remove(insert.Length - 1);
            insert += ");";
            insert = preInsert + insert;
            insert += @"SET IDENTITY_INSERT" + Table + "OFF;";

            //var sqlCommand = new SqlCommand(insert, Connection);

            SqlCommand sqlcommand = new SqlCommand(insert, Connection);

            foreach (var property in _properties)
            {
                sqlcommand.Parameters.AddWithValue
                    ("@" + property.Name + "Value",
                    property.GetValue(obj));
            }
            sqlcommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Read object from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override T Read(int id)
        {
            T obj = new T();

            string select = @"SELECT * FROM " + Table + " WHERE Id = @idValue;";
            SqlCommand sqlCommand = new SqlCommand(select, Connection);
            sqlCommand.Parameters.AddWithValue("@idValue", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var count = reader.FieldCount;

            if (reader.HasRows)
            {
                for (int i = 0; i < count; i++)
                {
                    var fieldName = reader.GetName(i);
                    var propInfo = typeof(T).GetProperty(fieldName);
                    propInfo?.SetValue(obj, reader.GetValue(i));
                }
            }
            return obj;
        }

        /// <summary>
        /// Read all collection objects of database
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<T> ReadAll()
        {
            string select = @"SELECT * from " + Table;
            SqlCommand sqlCommand = new SqlCommand(select, Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var list = new List<T>();
            var obj = new T();
            var typeOfT = typeof(T);

            var count = reader.FieldCount;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        var fieldName = reader.GetName(i);
                        var propInfo = typeOfT.GetProperty(fieldName);
                        propInfo?.SetValue(obj, reader.GetValue(i));
                    }
                    list.Add(obj);
                    obj = new T();
                }
            }
            return list;
        }

        /// <summary>
        /// Update object in database
        /// </summary>
        /// <param name="obj"></param>
        public override void Update(T obj)
        {
            string update = "UPDATE " + Table + " SET ";

            string idName = string.Empty;
            object idValue = null;

            foreach (var property in _properties)
            {
                if (property.Name == "Id")
                {
                    idName = property.Name;
                    idValue = property.GetValue(obj);
                    continue;
                }
                //update += "[" + property.Name + "]='" + property.GetValue(obj) + "',";
                update += "[" + property.Name + "]=@" + property.Name + "Value, ";
            }
            update = update.Remove(update.Length - 2);
            update += " WHERE [" + idName + "]=" + idValue + ";";

            SqlCommand sqlCommand = new SqlCommand(update, Connection);
            foreach (var property in _properties)
            {
                object value = property.GetValue(obj).ToString();
                sqlCommand.Parameters.AddWithValue("@" + property.Name + "Value", value);
            }
            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete object in database
        /// </summary>
        /// <param name="obj"></param>
        public override void Delete(T obj)
        {
            string delete = "DELETE FROM " + Table + " WHERE ";
            var property = _properties.First(o => o.Name == "Id");

            //delete += property.Name + "=" + property.GetValue(obj) + ";";
            delete += property.Name + "=@" + property.Name + "Value;";

            SqlCommand sqlCommand = new SqlCommand(delete, Connection);
            sqlCommand.Parameters.AddWithValue("@" + property.Name + "Value", property.GetValue(obj));
            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete object in database
        /// </summary>
        /// <param name="id"></param>

        public override void Delete(int id)
        {
            string delete = "DELETE FROM " + Table + " WHERE ";

            delete += " Id " + "='" + id + "';";

            SqlCommand sqlCommand = new SqlCommand(delete, Connection);
            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Set connectin in database
        /// </summary>
        /// <param name="connection"></param>
        public override void SetConnection(DbConnection connection)
        {
            Connection = (SqlConnection)connection;
        }
    }
}