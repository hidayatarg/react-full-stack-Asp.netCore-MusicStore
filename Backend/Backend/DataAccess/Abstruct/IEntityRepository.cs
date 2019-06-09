using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Backend.Entities;

namespace Backend.DataAccess.Abstruct
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void DeleteMany(List<T> entities);
        void Delete(T entity);
    }
}
