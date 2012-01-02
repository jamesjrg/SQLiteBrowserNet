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
using Microsoft.Win32;

namespace SQLiteBrowserNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM _vm;
        DbTreeVM _treeVM;
        
        public MainWindow()
        {
            _vm = new MainWindowVM();
            _treeVM = new DbTreeVM();

            InitializeComponent();
            this.DataContext = _vm;
            objectExplorer.DataContext = _treeVM;
            queryTabs.DataContext = _vm.QueryItemsList;
            resultsTabs.DataContext = _vm.QueryItemsList;

            OpenDB("../../../Japanese Kana.anki");
            ExecutedNewQueryCommand(null, null);
            ExecutedBrowseTableCommand(null, null);
        }

        private void OpenDB(string path)
        {
            try
            {
                _vm.OpenDB(path);                
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show(e.Message, "Failed to open database", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _treeVM.BuildTree();
        }

        #region commands

        private void ExecutedOpenDBCommand(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == true)
                OpenDB(d.FileName);
        }

        private void CanExecuteOpenDBCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }

        private void ExecutedExecuteQueryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ExecuteCurrentQuery();
        }

        private void CanExecuteExecuteQueryCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }

        private void ExecutedBrowseTableCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.NewQuery("SELECT * FROM tags");
            _vm.ExecuteCurrentQuery();
        }

        private void CanExecuteBrowseTableCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }

        private void ExecutedNewQueryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.NewQuery();
        }

        private void CanExecuteNewQueryCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            e.CanExecute = true;
        }

        private void ExecutedCloseQueryCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.CloseQuery();
        }

        private void CanExecuteCloseQueryCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            //XXX
            Control target = e.Source as Control;
            e.CanExecute = true;
        }

        #endregion commands
    }
}
