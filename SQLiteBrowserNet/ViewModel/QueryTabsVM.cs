using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SQLiteBrowserNet.Model;
using System.ComponentModel;
using System.Windows.Data;

namespace SQLiteBrowserNet.ViewModel
{
    class QueryTabsVM
    {
        ObservableCollection<Query> _queries = new ObservableCollection<Query>();

        public QueryTabsVM()
        {
            //XXX for closing tabs
            //_queries.CollectionChanged += this.OnWorkspacesChanged;
        }

        public ObservableCollection<Query> Queries
        {
            get { return _queries; }
        }

        public void NewQuery()
        {
            var query = new Query();
            _queries.Add(query);

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queries);
            collectionView.MoveCurrentTo(query);
        }

        public string GetCurrentText()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_queries);
            var query = (Query)collectionView.CurrentItem;
            return query.Text;
        }
    }
}
