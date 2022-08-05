using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

namespace ZBMS.DataLayer
{
    public class DBAdapter
    {
        private SqliteConnection _connection;
        private static readonly string connectionString = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "ZBMS_Database.db");

        public SqliteConnection GetConnection()
        {
            _connection = new SqliteConnection($"FileName={connectionString}");
            return _connection;
        }
    }
}
