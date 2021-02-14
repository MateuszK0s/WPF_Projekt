using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ToDoApp12329.Command;

namespace ToDoApp12329.ViewModels
{
    public class TaskAdderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ObservableCollection<TaskViewModel> _tasks;

        public ObservableCollection<TaskViewModel> tasks
        {
            get { return _tasks; }
            set
            {
                if (tasks != value)
                {
                    _tasks = value;
                    NotifyPropertyChanged(nameof(tasks));
                }
            }
        }

        public string taskName { get; set; }
        public ICommand CreateTaskCommand { get { return new CreateTaskCommand(); } }

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
