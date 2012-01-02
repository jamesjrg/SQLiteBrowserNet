using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLiteBrowserNet.Db;
using System.Data;
using SQLiteBrowserNet.Model;
using System.ComponentModel;
using System.Windows.Data;

namespace SQLiteBrowserNet.ViewModel
{
    class DbTreeVM
    {
        TreeNodeVM _rootObject;
        ObservableCollection<TreeNodeVM> _firstGeneration = new ObservableCollection<TreeNodeVM>();

        public DbTreeVM()
        {
            BuildTree();       
        }

        public ObservableCollection<TreeNodeVM> FirstGeneration
        {
            get { return _firstGeneration; }
        }

        public void BuildTree()
        {
            _rootObject = new TreeNodeVM(new RootNode());
            _firstGeneration.Clear();
            _firstGeneration.Add(_rootObject);
        }
    }
}
