using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SQLiteBrowserNet.Db;
using System.Data;

namespace SQLiteBrowserNet
{
    /// <summary>
    /// Interaction logic for ResultsTabs.xaml
    /// </summary>
    public partial class ResultsTabs : UserControl
    {
        public ResultsTabs()
        {
            InitializeComponent();
            NewQuery();
        }

        public void NewQuery()
        {
            DbConn conn = new DbConn();
            try
            {
                conn.Connect("../../../Japanese Kana.anki");
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show(e.Message, "Failed to open database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DataTable results = conn.ExecuteQuery("SELECT * FROM tags");
            resultsGrid1.ItemsSource = results.DefaultView;
        }
    }
}
