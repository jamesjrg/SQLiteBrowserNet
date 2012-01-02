using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteBrowserNet.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;

namespace SQLiteBrowserNet.ViewModel
{
    class QueryAndResultsVM
    {
        public Query Query { get; set; }
        public DataTable Results { get; set; }
        public ObservableCollection<String> Messages { get; set; }

        RelayCommand _closeCommand;

        public QueryAndResultsVM()
        {
            Query = new Query();
            Messages = new ObservableCollection<String>();
        }

        public void ExecuteQuery()
        {
            var query = Query.Text;

            try
            {
                Results = Global.Conn.ExecuteQuery(query);                
            }
            catch (Exception e)
            {
                Messages.Add(e.Message);
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => this.OnRequestClose());

                return _closeCommand;
            }
        }

        #region RequestClose [event]

        public event EventHandler RequestClose;

        void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
