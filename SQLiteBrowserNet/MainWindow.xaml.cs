using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using SQLiteBrowserNet.Db;
using System.Data;
using SQLiteBrowserNet.ViewModel;

namespace SQLiteBrowserNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand ExecuteQueryCommand = new RoutedCommand();

        private QueryTabsVM queryTabsVM = new QueryTabsVM();
        private DbConn conn = new DbConn();

        public MainWindow()
        {
            InitializeComponent();
            OpenDB("../../../Japanese Kana.anki");
            ExecutedExecuteQueryCommand(null, null);
        }

        private void OpenDB(string path)
        {
            try
            {
                conn.Connect(path);
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show(e.Message, "Failed to open database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecutedExecuteQueryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            DataTable results = conn.ExecuteQuery("SELECT * FROM tags");
            resultsTabs.resultsGrid1.ItemsSource = results.DefaultView;
            resultsTabs.tabControl.Items.Add(new TabItem());
        }

        private void CanExecuteExecuteQueryCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;
            e.CanExecute = true;
        }
    }
}
