using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAcces.Base
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private Context Context { get; set; }

        public Repository(Context context)
        {
            Context = context;
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }


        public virtual IQueryable<TEntity> Get()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
            Context.Set<TEntity>().Update(entity);
        }
        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(ICollection<TEntity> list)
        {
            Context.Set<TEntity>().RemoveRange(list);
        }

        public void AddRange(ICollection<TEntity> list)
        {
            Context.Set<TEntity>().AddRange(list);
        }
    }
}
