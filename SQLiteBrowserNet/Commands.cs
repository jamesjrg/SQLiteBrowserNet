using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SQLiteBrowserNet
{
    static class Commands
    {
        public static RoutedCommand OpenDBCommand = new RoutedCommand();
        public static RoutedCommand ExecuteQueryCommand = new RoutedCommand();
        public static RoutedCommand BrowseTableCommand = new RoutedCommand();
        public static RoutedCommand NewQueryCommand = new RoutedCommand();
        public static RoutedCommand OpenQueryCommand = new RoutedCommand();
        public static RoutedCommand SaveQueryCommand = new RoutedCommand();
        public static RoutedCommand CloseQueryCommand = new RoutedCommand();
    }
}
