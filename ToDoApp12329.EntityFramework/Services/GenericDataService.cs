using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp12329.Domain.Models;
using ToDoApp12329.Domain.Services;

namespace ToDoApp12329.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainModel
    {

        private readonly ToDoAppDbContextFactory _contextFactory;

        public GenericDataService(ToDoAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                var createdEntity = context.Set<T>().Add(entity);
                await context.SaveChangesAsync();

                return createdEntity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                T entity = context.Set<T>().FirstOrDefault((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                T entity = context.Set<T>().FirstOrDefault((e) => e.Id == id);

                return entity;
            }
        }

        public Task<IEnumerable<T>> GetAll()
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                IEnumerable<T> entities = context.Set<T>().ToList();

                return (Task<IEnumerable<T>>)entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                entity.Id = id;

                context.Set<T>().Add(entity);

                await context.SaveChangesAsync();

                return entity;
            }
        }

        public List<T> GetAllItems()
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                List<T> entities = context.Set<T>().ToList();

                return entities;
            }
        }
    }
}