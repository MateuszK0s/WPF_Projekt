using System.ComponentModel;

namespace ToDoApp12329.ViewModels
{
    using System.Collections.Generic;
    using ToDoApp12329.Models;
    public class TaskAdderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public List<string> taskList = new List<string>();
    }
}
