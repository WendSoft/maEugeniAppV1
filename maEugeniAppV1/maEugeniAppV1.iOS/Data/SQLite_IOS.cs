using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using maEugeniAppV1.Data;
using System.IO;
using Xamarin.Forms;
using maEugeniAppV1.iOS.Data;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace maEugeniAppV1.iOS.Data
{
   public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var Librarypath = Path.Combine(documentsPath, "...", "Library");
            var path = Path.Combine(Librarypath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}