using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApp12329
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyDateSet();
        }

        private string MyDateSet()
        {
            string dayOfWeek = DateTime.UtcNow.ToString("dddd");
            string dayOfMonth = DateTime.UtcNow.ToString("M");
            string myDayDateString = $"{dayOfWeek}, {dayOfMonth}";
            return (string)(myDayDate.Content = myDayDateString);
        }

        public void LoadTaskAdder()
        {

        }

        private void TaskAdderButton_Click(object sender, RoutedEventArgs e)
        {
            MyDayTasks.Items.Add("test");
        }
    }
}
