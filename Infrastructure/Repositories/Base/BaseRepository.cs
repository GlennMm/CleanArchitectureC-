using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {

        protected readonly ApplicationDataContext Context;

        public BaseRepository(ApplicationDataContext context)
        {
            Context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await Context.Set <T> ().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set <T> ().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set <T> ().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            var item = Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set <T> ().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}