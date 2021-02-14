using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp12329.EntityFramework
{
    public class ToDoAppDbContextFactory
    {
        public ToDoAppDbContext CreateContext()
        {
            return new ToDoAppDbContext();
        }
    }
}
