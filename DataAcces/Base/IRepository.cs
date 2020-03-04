using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAcces.Base
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Get();
        void Add(TEntity entity);
        void AddRange(ICollection<TEntity> entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(ICollection<TEntity> entity);
    }
}
