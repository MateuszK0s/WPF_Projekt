using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp12329.Domain.Models;
using ToDoApp12329.Domain.Services;
using ToDoApp12329.EntityFramework;
using ToDoApp12329.EntityFramework.Services;
using ToDoApp12329.ViewModels;


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
            var Tasks = new TaskAdderViewModel();
            Tasks.tasks = new ObservableCollection<TaskViewModel>();
            this.DataContext = Tasks;
        }
    }
}
