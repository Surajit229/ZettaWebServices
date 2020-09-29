using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ZettaWebServices.Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
        T SingleOrDefault(Expression<Func<T, bool>> whereCondition);
        T SingleOrDefaultWithInclude(Expression<Func<T, bool>> whereCondition, string propertyName);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> whereCondition);
        T Insert(T entity);
        void InsertAll(IList<T> entities);
        T Update(T entity);
        void UpdateAll(IList<T> entities);
        void Delete(Expression<Func<T, bool>> whereCondition);
        bool Exists(Expression<Func<T, bool>> whereCondition);
        T SingleOrDefaultOrderBy(Expression<Func<T, bool>> whereCondition, Expression<Func<T, int>> orderBy, string direction);
        int Count(Expression<Func<T, bool>> whereCondition);
        IQueryable<T> GetPagedRecords(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderBy, int pageNo, int pageSize);
    }
}
