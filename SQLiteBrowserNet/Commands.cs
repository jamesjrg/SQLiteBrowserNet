using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SQLiteBrowserNet
{
    static class Commands
    {
        public static readonly RoutedUICommand OpenDBCommand = new RoutedUICommand(
            "Open Database", "Open Database", typeof(Commands),
            new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control)});
        public static readonly RoutedUICommand ExecuteQueryCommand = new RoutedUICommand(
            "Execute", "Execute", typeof(Commands),
            new InputGestureCollection { new KeyGesture(Key.F5)});
        public static readonly RoutedUICommand BrowseTableCommand = new RoutedUICommand(
            "Browse Table", "Browse Table", typeof(Commands));
        public static readonly RoutedUICommand NewQueryCommand = new RoutedUICommand(
            "New Query", "New Query", typeof(Commands),
            new InputGestureCollection {
                new KeyGesture(Key.N, ModifierKeys.Control),
                new KeyGesture(Key.T, ModifierKeys.Control) });
        public static readonly RoutedUICommand OpenQueryCommand = new RoutedUICommand(
            "Open Query", "Open Query", typeof(Commands));
        public static readonly RoutedUICommand SaveQueryCommand = new RoutedUICommand(
            "Save Query", "Save Query", typeof(Commands));
        public static readonly RoutedUICommand CloseQueryCommand = new RoutedUICommand(
            "Close Query", "Close Query", typeof(Commands),
            new InputGestureCollection {
                new KeyGesture(Key.F4, ModifierKeys.Control),
                new KeyGesture(Key.W, ModifierKeys.Control) });
    }
}
