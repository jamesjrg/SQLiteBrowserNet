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
using System.Collections.Specialized;

namespace SQLiteBrowserNet.ViewModel
{
    class MainWindowVM
    {
        ObservableCollection<QueryAndResultsVM> _queryItems = new ObservableCollection<QueryAndResultsVM>();

        public MainWindowVM()
        {
            //XXX for closing tabs
            //_queries.CollectionChanged += this.OnWorkspacesChanged;
        }

        public void OpenDB(string path)
        {
            Global.Conn.Connect(path);
        }

        public ObservableCollection<QueryAndResultsVM> QueryItems
        {
            get
            {
                _queryItems.CollectionChanged += this.OnQueryItemsChanged;
                return _queryItems;
            }
        }

        void OnQueryItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (QueryAndResultsVM item in e.NewItems)
                    item.RequestClose += this.OnItemClose;
        }

        void OnItemClose(object sender, EventArgs e)
        {
            QueryAndResultsVM item = sender as QueryAndResultsVM;
            _queryItems.Remove(item);
        }

        public QueryAndResultsVM CurrentItem()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItems);
            return (QueryAndResultsVM)collectionView.CurrentItem;
        }

        public void NewQuery(string query="")
        {
            var items = new QueryAndResultsVM();
            items.Query.Text = query;
            _queryItems.Add(items);

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItems);
            collectionView.MoveCurrentTo(items);
        }

        public void CloseQuery()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItems);
            QueryAndResultsVM curr = (QueryAndResultsVM)collectionView.CurrentItem;
            _queryItems.Remove(curr);
        }

        public void ExecuteCurrentQuery()
        {
            CurrentItem().ExecuteQuery();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItems);
            collectionView.Refresh();
        }
    }
}
