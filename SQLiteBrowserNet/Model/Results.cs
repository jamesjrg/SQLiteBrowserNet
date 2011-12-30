using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SQLiteBrowserNet.Model
{
    abstract class ResultsTabItemBase
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
    }

    class ResultsData: ResultsTabItemBase
    {
        public ResultsData(DataTable results)
        {
            Title = "some results";
            ResultsTable = results;
        }

        public DataTable ResultsTable {get; set;}
    }

    class SchemaData: ResultsTabItemBase
    {
    }

    class MessagesData: ResultsTabItemBase
    {
        public List<string> MessagesList { get; set; }
    }
}
