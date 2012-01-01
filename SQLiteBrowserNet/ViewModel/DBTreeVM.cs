using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLiteBrowserNet.Db;
using System.Data;
using SQLiteBrowserNet.Model;

namespace SQLiteBrowserNet.ViewModel
{
    class DBTreeVM
    {
        DbConn _conn;
        TreeNodeVM _rootObject;
        ReadOnlyCollection<TreeNodeVM> _firstGeneration;

        public DBTreeVM(DbConn conn)
        {
            _conn = conn;

            BuildTree();            
        }

        public ReadOnlyCollection<TreeNodeVM> FirstGeneration
        {
            get { return _firstGeneration; }
        }

        public void BuildTree()
        {
            _rootObject = new TreeNodeVM(new RootNode(_conn));
            _firstGeneration = new ReadOnlyCollection<TreeNodeVM>(
                new TreeNodeVM[]
                { 
                    _rootObject
                });
        }
    }
}
