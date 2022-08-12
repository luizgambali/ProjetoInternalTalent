using Gambali.InternalTalent.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.Service.Interface
{
    public interface IBaseService<T> where T: class
    {
        Task<ResponseDTO> GetAllAsync();
        Task<ResponseDTO> GetOneAsync(int id);
        Task<ResponseDTO> InsertAsync(T entity);
        Task<ResponseDTO> UpdateAsync(T entity);
        Task<ResponseDTO> DeleteAsync(T entity);
    }
}
