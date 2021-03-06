﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp12329.ViewModels;

namespace ToDoApp12329.Command
{
    public class CreateTaskCommand : ICommand
    {
        public System.Windows.Input.CommandBindingCollection CommandBindings { get; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is TaskAdderViewModel taskList)
            {
                taskList.tasks.Add(new TaskViewModel() { name = taskList.taskName, isComplete = false });
            }
        }
    }
}
