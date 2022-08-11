using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _applicationDbContext;
        protected internal readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();
        }

        public virtual async Task<T> GetOneAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByCriteria(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task InsertRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        protected async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
