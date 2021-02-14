using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ToDoApp12329.Views
{
    using ToDoApp12329.ViewModels;
    /// <summary>
    /// Interaction logic for TaskAdderView.xaml
    /// </summary>
    public partial class TaskAdderView : UserControl
    {
        public TaskAdderView()
        {
            InitializeComponent();
            DataContext = new DataObject();
        }

        class DataObject
        {
            public DataObject()
            {
                List<string> taskList = new List<string>();
            }
        }

        private void saveTaskButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
