using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SQLiteBrowserNet.Model;

namespace SQLiteBrowserNet.ViewModel
{
    class QueryTabsVM
    {
        ObservableCollection<Query> _queries = new ObservableCollection<Query>();

        public QueryTabsVM()
        {
            //XXX _queries.CollectionChanged += this.OnWorkspacesChanged;
        }

        public ObservableCollection<Query> Queries
        {
            get { return _queries; }
        }

        public void NewQuery()
        {
            _queries.Add(new Query());
        }
    }
}
