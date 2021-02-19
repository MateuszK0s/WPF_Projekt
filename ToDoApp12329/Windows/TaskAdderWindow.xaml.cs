using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace ToDoApp12329.Windows
{
    /// <summary>
    /// Interaction logic for TaskAdderWindow.xaml
    /// </summary>
    public partial class TaskAdderWindow : Window
    {
        public TaskAdderWindow()
        {
            InitializeComponent();            
        }

        private void TaskSaverButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Owner = mainWindow;
        }

        public void ShowDialog(Window owner)
        {
            this.Owner = owner;
            this.ShowDialog();
        }

        public void Show(Window owner)
        {
            this.Owner = owner;
            this.Show();
        }
    }
}
