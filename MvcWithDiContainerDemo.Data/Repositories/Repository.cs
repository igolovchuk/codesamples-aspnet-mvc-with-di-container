using MvcWithDiContainerDemo.Data.Entities;
using MvcWithDiContainerDemo.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcWithDiContainerDemo.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T>
         where T : class
    {
        protected DbSet<T> _objectSet;

        public Repository(ApplicationDbContext context)
        {
            _objectSet = context.Set<T>();
        }

        #region IRepository<T> Members

        public abstract T GetById(object id);

        public IQueryable<T> GetAll()
        {
            return _objectSet;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _objectSet.Where(filter);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _objectSet.Remove(entity);
        }

        #endregion
    }
}
