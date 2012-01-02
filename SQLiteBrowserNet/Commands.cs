using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SQLiteBrowserNet
{
    static class Commands
    {
        public static readonly RoutedCommand OpenDBCommand = new RoutedCommand();
        public static readonly RoutedCommand ExecuteQueryCommand = new RoutedCommand();
        public static readonly RoutedCommand BrowseTableCommand = new RoutedCommand();
        public static readonly RoutedCommand NewQueryCommand = new RoutedCommand();
        public static readonly RoutedCommand OpenQueryCommand = new RoutedCommand();
        public static readonly RoutedCommand SaveQueryCommand = new RoutedCommand();
        public static readonly RoutedCommand CloseQueryCommand = new RoutedCommand();
    }
}
