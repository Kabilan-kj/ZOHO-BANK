using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS
{
    public class DatabaseHandler
    {
        protected static readonly string dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "ZBMS_Database.db");
        protected SqliteConnection db = new SqliteConnection($"FileName={dbpath}");

        protected void CreateConnection()
        {
            db = new SqliteConnection($"FileName={dbpath}");
        }
    }
}
