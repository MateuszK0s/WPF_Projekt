using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp12329.Domain.Models;

namespace ToDoApp12329.EntityFramework
{
    public class ToDoAppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; } 
        public DbSet<TeamMember> Members { get; set; }

        public ToDoAppDbContext() : base("ToDoAppDbContext")
        {

        }
    }
}
