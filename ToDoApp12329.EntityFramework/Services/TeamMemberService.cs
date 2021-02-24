using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp12329.Domain.Services;
using ToDoApp12329.EntityFramework;
using TeamMember = ToDoApp12329.Domain.Models.TeamMember;

namespace TodoApp.EntityFramework.Services
{
    public class TeamMemberService : IDataService<TeamMember>
    {
        private readonly ToDoAppDbContextFactory _contextFactory;

        public TeamMemberService(ToDoAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<TeamMember> Create(TeamMember entity)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {

                var createdEntity = context.Members.Add(entity);
                await context.SaveChangesAsync();

                return createdEntity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                TeamMember entity = context.Set<TeamMember>().FirstOrDefault((e) => e.Id == id);
                context.Set<TeamMember>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<TeamMember> Get(int id)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                TeamMember entity = context.Set<TeamMember>().FirstOrDefault((e) => e.Id == id);

                return entity;
            }
        }


        public async Task<IEnumerable<TeamMember>> GetAll()
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                IEnumerable<TeamMember> entities = await context.Set<TeamMember>().ToListAsync();

                return entities;
            }
        }

        public async Task<TeamMember> Update(int id, TeamMember entity)
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                entity.Id = id;

                context.Set<TeamMember>().Add(entity);

                await context.SaveChangesAsync();

                return entity;
            }
        }

        public List<TeamMember> GetAllMembers()
        {
            using (ToDoAppDbContext context = _contextFactory.CreateContext())
            {
                List<TeamMember> entities = context.Set<TeamMember>().ToList();

                return entities;
            }
        }
    }
}