using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteBrowserNet.Db;
using System.Data.SQLite;

namespace SQLiteBrowserNet
{
    class Global
    {
        static private DbConn _conn = new DbConn();
        static public DbConn Conn
        {
            get { return _conn; }
        }

        static public SQLiteConnection RealConn
        {
            get { return _conn.RealConn; }
        }

    }
}
