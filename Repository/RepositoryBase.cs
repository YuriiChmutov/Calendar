using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        
        public async Task<List<ToDo>> FindAll()
        {
            // return this.RepositoryContext.Set<T>().AsNoTracking();
            return await Task.Run(() => this.RepositoryContext.Tasks.ToListAsync());
        }

        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => 
                this.RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync());
        }
        
        public async Task Create(T entity)
        {
            await Task.Run(() => this.RepositoryContext.Set<T>().Add(entity));
        }
        
        public async Task Update(T entity)
        {
            await Task.Run(() => this.RepositoryContext.Set<T>().Update(entity));
        }
        
        public async Task Delete(T entity)
        {
            await Task.Run(() => this.RepositoryContext.Set<T>().Remove(entity));
        }
    }
}