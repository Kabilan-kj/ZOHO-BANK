using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ZBMS
{
    public class SqliteDBAdapter
    {
        protected static readonly string dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "ZBMS_Database.db");
        protected SqliteConnection db = new SqliteConnection($"FileName={dbpath}");

        protected void CreateConnection()
        {
            db = new SqliteConnection($"FileName={dbpath}");
        }
    }

}
