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

        public string _mainLabel;
        public string MainLabel
        {
            get { return _mainLabel; }
            set { _mainLabel = value; this.RaisePropertyChanged("TasksSum"); }
        }

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
            set { _tasksSum = Tasks.Count; this.RaisePropertyChanged("TasksSum"); }
        }

        private int _allTasksSum;
        public int AllTasksSum
        {
            get { return _allTasksSum; }
            set { _allTasksSum = value; this.RaisePropertyChanged("AllTasksSum"); }
        }

        private List<TeamMember> _members;
        public List<TeamMember> Members
        {
            get { return _members; }
            set { _members = value; this.RaisePropertyChanged("Members"); }
        }

        private int _membersCount;
        public int MembersCount
        {
            get { return _membersCount; }
            set { _membersCount = value; this.RaisePropertyChanged("MembersCount"); }
        }

        public MainWindow()
        {
            UpdateTasksList();
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
            TaskAdderWindow AddTaskWindow = new TaskAdderWindow(this);
            AddTaskWindow.ShowDialog();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TasksButton_Click(object sender, RoutedEventArgs e)
        {
            MainLabel = "Tasks";
            DataContext = new TaskListView();
            mainLabel.Content = "Tasks";

        }

        private void MyDayButton_Click(object sender, RoutedEventArgs e)
        {
            MainLabel = "My Day";
            DataContext = new MyDayTasksView();
            mainLabel.Content = "My Day";

        }

        public void UpdateTasksList()
        {
            DataTaskService taskService = new DataTaskService(new ToDoAppDbContextFactory());
            DateTime today = DateTime.Today;
            Tasks = taskService.GetByDates(today);
            TasksSum = Tasks.Count;
            Tasks = taskService.GetAllItems();
            AllTasksSum = Tasks.Count;

            TeamMemberService memberService = new TeamMemberService(new ToDoAppDbContextFactory());
            Members = memberService.GetAllMembers();
            MembersCount = Members.Count;
        }

        private void MembersButton_Click(object sender, RoutedEventArgs e)
        {
            MainLabel = "Team members";
            DataContext = new TeamMembersView();
            mainLabel.Content = "Team members";
        }
    }
}
