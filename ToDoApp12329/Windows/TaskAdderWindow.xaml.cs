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
using ToDoApp12329.Domain.Models;
using ToDoApp12329.Domain.Services;
using ToDoApp12329.EntityFramework;
using ToDoApp12329.EntityFramework.Services;

namespace ToDoApp12329.Windows
{
    /// <summary>
    /// Interaction logic for TaskAdderWindow.xaml
    /// </summary>
    public partial class TaskAdderWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MainWindow MainWindow { get; set; }
        public TaskAdderWindow(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();            
        }

        private void TaskSaverButtonClick(object sender, RoutedEventArgs e)
        {
            IDataService<TaskItem> taskItem = new GenericDataService<TaskItem>(new ToDoAppDbContextFactory());

            taskItem.Create(new TaskItem
            {
                TaskName = this.taskNameTextBox.Text,
                TaskDescription = this.taskDescriptionTextBox.Text,
                TaskDate = this.TaskDataPicker.SelectedDate
                
            });
            MainWindow.UpdateTasksList();
            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.UpdateTasksList();
            this.Close();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
