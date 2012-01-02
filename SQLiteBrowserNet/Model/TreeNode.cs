using System;
using System.Collections.Generic;
using SQLiteBrowserNet.Db;
using System.Data;

namespace SQLiteBrowserNet.Model
{
    class TreeNode
    {
        protected List<TreeNode> _children = new List<TreeNode>();
        public IList<TreeNode> Children
        {
            get { return _children; }
        }

        public string Name { get; set; }
    }

    class RootNode : TreeNode
    {
        public RootNode()
        {
            if (Global.RealConn.State == ConnectionState.Closed)
            {
                Name = "No database";
            }
            else
            {
                Name = Global.RealConn.DataSource;

                DataTable tables = Global.RealConn.GetSchema("Tables");
                
                foreach (DataRow row in tables.Rows)
                    _children.Add(new TableNode(row.ItemArray));
            }
        }
    }

    class TableNode : TreeNode
    {
        public TableNode(object[] row)
        {
            if (row.Length > 2)
                Name = row[2].ToString();
            else
                Name = "error";
        }
    }

    class TestNode : TreeNode
    {
        public TestNode(string name)
        {
            Name = name;
        }
    }
}
