//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;


//namespace ToDoApp12329.Views
//{
//    using ToDoApp12329.Domain.Models;
//    using ToDoApp12329.Domain.Services;
//    using ToDoApp12329.EntityFramework;
//    using ToDoApp12329.EntityFramework.Services;
//    using ToDoApp12329.ViewModels;
//    /// <summary>
//    /// Interaction logic for TaskAdderView.xaml
//    /// </summary>
//    public partial class TaskAdderView : UserControl
//    {
//        private TaskItem _taskItem = new TaskItem();
//        public TaskAdderView()
//        {            
//            InitializeComponent();            
//            DataContext = new DataObject();            
//        }

//        class DataObject
//        {
//            public DataObject()
//            {
//                List<string> taskList = new List<string>();
//            }
//        }

//        private void saveTaskButton_Click(object sender, RoutedEventArgs e)
//        {
//            IDataService<TaskItem> taskItem = new GenericDataService<TaskItem>(new ToDoAppDbContextFactory());            

//            taskItem.Create(new TaskItem
//            {
//                TaskName = taskNameTextBox.Text,
//                TaskDescription = taskTextBox.Text
//            }) ;

//            InitializeComponent();
//        }

//        private void testInit(object sender, EventArgs e)
//        {
            
//        }
//    }
//}
