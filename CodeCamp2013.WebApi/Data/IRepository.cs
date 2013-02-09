using System;
using System.Linq;
using System.Linq.Expressions;

namespace CodeCamp2013.WebApi.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        IQueryable<T> Find(Expression<Func<T, bool>> exp);
        T FindSingle(Expression<Func<T, bool>> exp);
        void InsertOrUpdate(T entity);
        void Delete(int id);
        void Save();
    }
}