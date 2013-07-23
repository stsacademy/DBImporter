using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using STSdb4.Data;

namespace DBImporter
{
    public class AccessReader : IReader
    {
        private OleDbConnection connection;

        public string DBName { get; set; }

        public string ConnectionString { get; set; }

        public OleDbConnection Connection { get { return this.connection; } }

        public AccessReader(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void OpenConnection()
        {
            connection = new OleDbConnection(ConnectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public IEnumerable<object[]> ExtractData(string tableName, string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
                fields[i] = "[" + fields[i] + "]";

            string _fields = string.Join(", ", fields);
            string query = string.Format("Select {0} FROM {1};", _fields, tableName);

            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                object[] row = new object[reader.FieldCount];
                reader.GetValues(row);

                yield return row;
            }
        }

        public string[] GetTableNames()
        {
            List<string> names = new List<string>();
            foreach (DataRow tableName in connection.GetSchema("Tables").Select("TABLE_TYPE = 'TABLE'"))
                names.Add(tableName["TABLE_NAME"].ToString());

            return names.ToArray();
        }

        public Type[] GetFieldTypes(string tableName, string[] fields)
        {
            List<Type> types = new List<Type>();

            for (int i = 0; i < fields.Length; i++)
                fields[i] = "[" + fields[i] + "]";

            string _fields = string.Join(", ", fields);

            string query = string.Format("Select {0} FROM {1};", _fields, tableName);

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
                types.Add(reader.GetFieldType(i));

            return types.ToArray();
        }

        public IEnumerable<string> GetFieldNames(string selectedTable)
        {
            string query = string.Format("Select * From {0}", selectedTable);

            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
                yield return reader.GetName(i);
        }
    }
}
