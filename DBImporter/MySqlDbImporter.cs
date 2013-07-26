using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using STSdb4.Data;
using DBImporter;
using MySql.Data.MySqlClient;

namespace AccessDbImporter
{
    public class MySqlDbImporter : IReader
    {
        public string DBName { get; set; }     

        public string ConnectionString { get; set; }

        private MySqlConnection connection;

        private MySqlDataReader readr;
       
        public MySqlConnection Connection { get { return this.connection; } }

        public MySqlDbImporter(string connStr)
        {
            ConnectionString = connStr;
        }

        public void OpenConnection()
        {           
            connection = new MySqlConnection(ConnectionString);
            connection.Open();                      
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public string[] GetTableNames()
        {
            string query = "Show tables from test";

            List<String> TableNames = new List<String>();

            MySqlCommand command = new MySqlCommand(query, connection);

            using (readr = command.ExecuteReader())
            {
                while (readr.Read())
                {
                    TableNames.Add(readr.GetString(0));
                }

            }
            readr.Close();
            return TableNames.ToArray();
        }

        public Type[] GetFieldTypes(string tableName, string[] fields)
        {
            List<Type> types = new List<Type>();

            for (int i = 0; i < fields.Length; i++)
                fields[i] = "`" + fields[i] + "`";
            string _fields = string.Join(", ", fields);

            string query = string.Format("Select {0} FROM {1};", _fields, tableName);

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            MySqlCommand command = new MySqlCommand(query, conn);

            readr = command.ExecuteReader();
           
            for (int i = 0; i < readr.FieldCount; i++)
               types.Add(readr.GetFieldType(i));
               
            readr.Close();
            return types.ToArray();
        }

        public IEnumerable<object[]> ExtractData(string tableName, string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
                fields[i] = "`" + fields[i] + "`";
            string _fields = string.Join(", ", fields);

            string query = string.Format("Select {0} FROM {1};", _fields, tableName);

            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                object[] row = new object[reader.FieldCount];
                reader.GetValues(row);

                yield return row;
            }
        }

        public IEnumerable<string> GetFieldNames(string selectedTable)
        {
            string query = string.Format("Select * From {0}", selectedTable);

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
                yield return reader.GetName(i);
        }

    }
}
