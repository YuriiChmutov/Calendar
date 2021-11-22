using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<List<ToDo>> FindAll();
        Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}