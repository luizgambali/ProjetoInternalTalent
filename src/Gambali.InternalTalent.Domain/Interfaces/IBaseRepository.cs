using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetOneAsync(int id);
        Task<IEnumerable<T>> GetByCriteria(Expression<Func<T, bool>> predicate);
        Task<T> InsertAsync(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
