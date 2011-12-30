using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using SQLiteBrowserNet.Db;
using SQLiteBrowserNet.Model;
using System.ComponentModel;
using System.Windows.Data;

namespace SQLiteBrowserNet.ViewModel
{
    class ResultsTabsVM
    {
        ObservableCollection<ResultsTabItemBase> _results = new ObservableCollection<ResultsTabItemBase>();

        public ObservableCollection<ResultsTabItemBase> Results
        {
            get { return _results; }
        }

        public void NewResult(DbConn conn, string query)
        {
            var result = new ResultsData(conn.ExecuteQuery(query));
            _results.Add(result);

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(_results);
            if (collectionView != null)
                collectionView.MoveCurrentTo(result);
        }
    }
}
