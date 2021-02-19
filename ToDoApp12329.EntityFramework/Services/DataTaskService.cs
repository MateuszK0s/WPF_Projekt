using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp12329.Domain.Services;
using ToDoApp12329.EntityFramework;
using TaskItem = ToDoApp12329.Domain.Models.TaskItem;

namespace TodoApp.EntityFramework.Services
{
    public class DataTaskService : IDataService<TaskItem>
    {
        private readonly ToDoAppDbContextFactory _contextFactory;

        public DataTaskService(ToDoAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<TaskItem> Create(TaskItem entity)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {

                var createdEntity = context.Tasks.Add(entity);
                await context.SaveChangesAsync();

                return createdEntity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                TaskItem entity = context.Set<TaskItem>().FirstOrDefault((e) => e.Id == id);
                context.Set<TaskItem>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<TaskItem> Get(int id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                TaskItem entity = context.Set<TaskItem>().FirstOrDefault((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                IEnumerable<TaskItem> entities = await context.Set<TaskItem>().ToListAsync();

                return entities;
            }
        }

        public async Task<TaskItem> Update(int id, TaskItem entity)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                entity.Id = id;

                context.Set<TaskItem>().Add(entity);

                await context.SaveChangesAsync();

                return entity;
            }
        }

        public List<TaskItem> GetAllItems()
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                List<TaskItem> entities = context.Set<TaskItem>().ToList();

                return entities;
            }
        }
    }
}