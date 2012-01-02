using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SQLiteBrowserNet.Model;
using System.ComponentModel;
using System.Windows.Data;
using System.Data;
using SQLiteBrowserNet.Db;
using System.Windows.Input;

namespace SQLiteBrowserNet.ViewModel
{
    class MainWindowVM
    {
        ObservableCollection<QueryAndResultsVM> _queryItemsList = new ObservableCollection<QueryAndResultsVM>();

        public MainWindowVM()
        {
            //XXX for closing tabs
            //_queries.CollectionChanged += this.OnWorkspacesChanged;
        }

        public void OpenDB(string path)
        {
            Global.Conn.Connect(path);
        }

        public ObservableCollection<QueryAndResultsVM> QueryItemsList
        {
            get { return _queryItemsList; }
        }

        public QueryAndResultsVM CurrentItems()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
            return (QueryAndResultsVM)collectionView.CurrentItem;
        }

        public void NewQuery(string query="")
        {
            var items = new QueryAndResultsVM();
            items.Query.Text = query;
            _queryItemsList.Add(items);

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
            collectionView.MoveCurrentTo(items);
        }

        public void CloseQuery()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
            QueryAndResultsVM curr = (QueryAndResultsVM)collectionView.CurrentItem;
            _queryItemsList.Remove(curr);
        }

        public void ExecuteCurrentQuery()
        {
            CurrentItems().ExecuteQuery();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
            collectionView.Refresh();
        }
    }
}
