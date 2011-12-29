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
using SQLiteBrowserNet.Model;

namespace SQLiteBrowserNet.View
{
    /// <summary>
    /// Interaction logic for ResultsTabs.xaml
    /// </summary>
    public partial class ResultsTabs : UserControl
    {
        public ResultsTabs()
        {
            InitializeComponent();
        }
    }

    class ResultsTabDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            Type t = item.GetType();

            if (t == typeof(ResultsData))
                return element.FindResource("importantTaskTemplate") as DataTemplate;
            else if (t == typeof(SchemaData))
                return element.FindResource("importantTaskTemplate") as DataTemplate;
            else if (t == typeof(MessagesData))
                return element.FindResource("importantTaskTemplate") as DataTemplate;
            return null;
        }
    }
}
