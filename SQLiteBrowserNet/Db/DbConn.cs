using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SQLite;
using System.Data;

namespace SQLiteBrowserNet.Db
{
    public class DbConn
    {
        private SQLiteConnection conn = new SQLiteConnection();

        public void Connect(string filename)
        {
            Close();
            conn = new SQLiteConnection("Data Source=" + filename + ";");
            conn.Open();
        }

        public void Dispose()
        {
            Close();
        }

        public void Close()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        public DataTable ExecuteQuery(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void ExecuteNonQuery(string stmt)
        {
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            return cmd.ExecuteScalar();
        }

        public SQLiteConnection RealConn
        {
            get { return conn; }
        }
    }
}
