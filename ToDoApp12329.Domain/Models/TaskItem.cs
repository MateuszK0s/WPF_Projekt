using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp12329.Domain.Models
{
    public class TaskItem : DomainModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? TaskDate { get; set; }
    }
}
