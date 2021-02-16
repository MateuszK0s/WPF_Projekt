﻿using System;
using System.Collections.Generic;
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
            using(ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                var createdEntity = context.Set<T>().Add(entity);
                await context.SaveChangesAsync();

                return createdEntity;
            }
        }

        public async Task<T> Get(int Id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                T entity = context.Set<T>().FirstOrDefault((e) => e.Id == Id);

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

        public Task<T> Update(int Id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
