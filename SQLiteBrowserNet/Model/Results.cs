using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SQLiteBrowserNet.Model
{
    abstract class ResultsTabItemBase
    {
    }

    class ResultsData: ResultsTabItemBase
    {
        public ResultsData(DataTable results)
        {
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
