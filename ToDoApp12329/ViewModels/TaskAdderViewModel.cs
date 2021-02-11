using System.ComponentModel;

namespace ToDoApp12329.ViewModels
{
    using ToDoApp12329.Models;
    public class TaskAdderViewModel : INotifyPropertyChanged
    {
        private string _test = "VM Test";
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                if (_test == value)
                    return;

                _test = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }
    }
}
