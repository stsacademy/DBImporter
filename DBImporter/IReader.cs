using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBImporter
{
    public interface IReader
    {
        string ConnectionString { get; set; }

        void OpenConnection();

        void CloseConnection();

        string[] GetTableNames();

        Type[] GetFieldTypes(string tableName, string[] fields);

        IEnumerable<object[]> ExtractData(string tableName, string[] fields);

        IEnumerable<string> GetFieldNames(string tableName);
    }
}

