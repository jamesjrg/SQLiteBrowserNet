using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SQLiteBrowserNet.ViewModel
{
    class Query
    {
        public string Text {get; set;}
        public bool IsModified { get; set; }
    }

    class QueryTabsVM
    {
        public ObservableCollection<Query> queries;

        public void NewQuery()
        {
            queries.Add(new Query());
        }
    }
}
