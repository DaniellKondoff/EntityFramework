using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SoftUni.Data.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
        void DeleteRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
        T Attach(T entity);
        void Detach(T entity);
    }
}
