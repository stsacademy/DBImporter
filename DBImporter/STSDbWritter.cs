using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STSdb4.Database;
using STSdb4.Data;
using System.IO;
using System.Threading;

namespace DBImporter
{
    public class STSDbWritter
    {
        private Thread Worker = null;

        public event ReportProgressDelegate Log;

        public IStorageEngine Engine { get; private set; }

        public Dictionary<string, List<FieldSaver>> SelectedTables { get; private set; }

        public IReader Reader { get; private set; }

        public string FilePath { get; private set; }

        public string DbDir { get; private set; }

        public STSDbWritter(IReader reader, string filePath, string dbDir, Dictionary<string, List<FieldSaver>> selectedTables)
        {
            Reader = reader;

            FilePath = filePath;

            DbDir = dbDir;

            SelectedTables = selectedTables;
        }

        public void Start()
        {
            Worker = new Thread(DoWork);
            Worker.Start();
        }

        public void Stop()
        {
            if (Worker != null)
                Worker.Abort();
        }

        private void DoWork()
        {
            using (Engine = STSdb.FromFile(Path.Combine(DbDir, "stsdb4.sys"), Path.Combine(DbDir, "stsdb4.dat")))            
            {
                OnLog("INF", "Service", "Started", "New session started.");
                OnLog("INF", "Service", "FilePath)", FilePath);
                OnLog("INF", "Service", "DbDir", DbDir);

                foreach (var table in SelectedTables)
                {
                    string tableName = table.Key;
                    List<string> fields = table.Value.GetSelectedFields();

                    if (fields.Count > 0)
                    {
                        Type[] types = Reader.GetFieldTypes(tableName, fields.ToArray());

                        StoreTable(tableName, fields.ToArray(), types);

                        OnLog("INF", "TableName", tableName, "extracted.");
                    }

                    Engine.Commit();
                }

                OnLog("INF", "Service", "Progress", "Finished");
                OnLog("----------------------------------------------------------------------------------------------------------");
            }
        }

        private void StoreTable(string tableName, string[] fields, Type[] recordTypes)
        {
            DataType[] recDataType = new DataType[recordTypes.Length];
            for (int i = 0; i < recordTypes.Length; i++)
                recDataType[i] = DataType.FromPrimitiveType(recordTypes[i]);

            IIndex<IData, IData> table = Engine.OpenXIndex(new DataType[] { DataType.Int64 }, recDataType, true, true, tableName);
            DataToObjectsTransformer transformer = new DataToObjectsTransformer(recDataType);

            long keyCounter = 0;
            foreach (var row in Reader.ExtractData(tableName, fields))
            {
                STSdb4.Data.IData key = new STSdb4.Data.Data<long>(keyCounter);
                table[key] = transformer.ToIData(row);
                keyCounter++;
            }

            table.Flush();
        }

        //[status][time][session][info][Message]

        public void OnLog(string status, string session, string info, string message)
        {
            OnLog(string.Format("[{0}][{1}][{2}][{3}][{4}]", status, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), session, info, message));
        }

        public void OnLog(string message)
        {
            if (Log != null)
                Log(this, message);
        }

        public delegate void ReportProgressDelegate(STSDbWritter sender, string message);
    }
}
