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

namespace SQLiteBrowserNet.ViewModel
{
    class QueryItems
    {
        public QueryItems()
        {
            Query = new Query();
            Messages = new ObservableCollection<String>();
        }

        public Query Query { get;set; }
        public DataTable Results { get; set; }
        public ObservableCollection<String> Messages { get;set; }
    }

    class MainWindowVM
    {
        DbConn _conn;
        ObservableCollection<QueryItems> _queryItemsList = new ObservableCollection<QueryItems>();

        public MainWindowVM(DbConn conn)
        {
            _conn = conn;
            //XXX for closing tabs
            //_queries.CollectionChanged += this.OnWorkspacesChanged;
        }

        public void OpenDB(string path)
        {
            _conn.Connect(path);
        }

        public ObservableCollection<QueryItems> QueryItemsList
        {
            get { return _queryItemsList; }
        }

        public void NewQuery(string query="")
        {
            var items = new QueryItems();
            items.Query.Text = query;
            _queryItemsList.Add(items);

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
            collectionView.MoveCurrentTo(items);
        }

        public QueryItems CurrentItems()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
            return (QueryItems)collectionView.CurrentItem;
        }

        public void ExecuteCurrentQuery()
        {
            var query = CurrentItems().Query.Text;
            var currentItems = CurrentItems();

            try
            {
                currentItems.Results = _conn.ExecuteQuery(query);
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queryItemsList);
                collectionView.Refresh();
            }
            catch (Exception e)
            {
                currentItems.Messages.Add(e.Message);
            }
        }
    }
}
