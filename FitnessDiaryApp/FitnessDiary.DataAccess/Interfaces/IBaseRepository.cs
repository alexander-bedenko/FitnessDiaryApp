using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitnessDiary.DataAccess.Entities;

namespace FitnessDiary.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task Create(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}