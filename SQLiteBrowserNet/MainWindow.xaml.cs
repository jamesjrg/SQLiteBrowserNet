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
        public static RoutedCommand BrowseTableCommand = new RoutedCommand();
        public static RoutedCommand NewQueryCommand = new RoutedCommand();

        DbConn _conn = new DbConn();
        QueryTabsVM _queryTabsVM = new QueryTabsVM();
        ResultsTabsVM _resultsTabsVM = new ResultsTabsVM();
        
        public MainWindow()
        {
            InitializeComponent();
            queryTabs.DataContext = _queryTabsVM;
            resultsTabs.DataContext = _resultsTabsVM;

            OpenDB("../../../Japanese Kana.anki");
            ExecutedBrowseTableCommand(null, null);
            ExecutedBrowseTableCommand(null, null);
            ExecutedNewQueryCommand(null, null);
            ExecutedNewQueryCommand(null, null);
        }

        private void OpenDB(string path)
        {
            try
            {
                _conn.Connect(path);
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show(e.Message, "Failed to open database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecutedExecuteQueryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _resultsTabsVM.NewResult(_conn, _queryTabsVM.GetCurrentText());
        }

        private void CanExecuteExecuteQueryCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }

        private void ExecutedBrowseTableCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _resultsTabsVM.NewResult(_conn, "SELECT * FROM tags");
        }

        private void CanExecuteBrowseTableCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }

        private void ExecutedNewQueryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _queryTabsVM.NewQuery();
        }

        private void CanExecuteNewQueryCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }
    }
}
