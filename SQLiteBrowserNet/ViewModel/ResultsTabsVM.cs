using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using SQLiteBrowserNet.Db;
using SQLiteBrowserNet.Model;

namespace SQLiteBrowserNet.ViewModel
{
    class ResultsTabsVM
    {
        ObservableCollection<ResultsTabItemBase> _results = new ObservableCollection<ResultsTabItemBase>();

        public ObservableCollection<ResultsTabItemBase> Results
        {
            get { return _results; }
        }

        public void NewResult(DbConn conn)
        {
            //_results.Add(new ResultsData(conn.ExecuteQuery("SELECT * FROM tags")));
            //XXX resultsTabs.resultsGrid1.ItemsSource = results.DefaultView;
        }
    }
}
