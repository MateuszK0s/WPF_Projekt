using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TodoApp.EntityFramework.Services;
using ToDoApp12329.Domain.Models;
using ToDoApp12329.EntityFramework;

namespace ToDoApp12329.Views
{
    /// <summary>
    /// Interaction logic for MyDayTasksView.xaml
    /// </summary>
    public partial class MyDayTasksView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<TaskItem> _tasks;
        public List<TaskItem> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; this.RaisePropertyChanged("Tasks"); }
        }

        private int _tasksSum;
        public int TasksSum
        {
            get { return _tasksSum; }
            set { _tasksSum = value; this.RaisePropertyChanged("Tasks"); }
        }

        private int _allTasksSum;
        public int AllTasksSum
        {
            get { return _allTasksSum; }
            set { _allTasksSum = value; this.RaisePropertyChanged("Tasks"); }
        }

        public MyDayTasksView()
        {
            DataTaskService taskService = new DataTaskService(new ToDoAppDbContextFactory());
            Tasks = taskService.GetAllItems();
            AllTasksSum = Tasks.Count;
            DateTime today = DateTime.Today;
            Tasks = taskService.GetByDates(today);
            TasksSum = Tasks.Count;

            InitializeComponent();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
