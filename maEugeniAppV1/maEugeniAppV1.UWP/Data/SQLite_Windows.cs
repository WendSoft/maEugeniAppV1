using maEugeniAppV1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using Xamarin.Forms;
using maEugeniAppV1.UWP.Data;

[assembly: Dependency(typeof(SQLite_Windows))]

namespace maEugeniAppV1.UWP.Data
{
    class SQLite_Windows : ISQLite
    {
        public SQLite_Windows() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
