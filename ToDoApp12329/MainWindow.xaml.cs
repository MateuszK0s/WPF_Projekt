using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using ToDoApp12329.Views;
using ToDoApp12329.Windows;

namespace ToDoApp12329
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<TaskItem> _tasks;
        public List<TaskItem> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; this.RaisePropertyChanged("Tasks"); }
        }

        private int _tasksSum;
        public int TasksSum
        {
            get { return _tasksSum; }
            set { _tasksSum = Tasks.Capacity; this.RaisePropertyChanged("Tasks"); }
        }


        public MainWindow()
        {
            DataContext = new MyDayTasksView();            
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

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TasksButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TaskListView();
        }

        private void MyDayButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MyDayTasksView();
        }
    }
}
