using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TodoApp.EntityFramework.Services;
using ToDoApp12329.Domain.Models;
using ToDoApp12329.Domain.Services;
using ToDoApp12329.EntityFramework;
using ToDoApp12329.EntityFramework.Services;
using ToDoApp12329.ViewModels;
using ToDoApp12329.Windows;

namespace ToDoApp12329
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            IDataService<TaskItem> Tasks = new DataTaskService(new ToDoAppDbContextFactory());
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

        private void TaskAdderButton_Click(object sender, RoutedEventArgs e)
        {
            TaskAdderWindow AddTaskWindow = new TaskAdderWindow();
            AddTaskWindow.ShowDialog();
        }        
    }
}
