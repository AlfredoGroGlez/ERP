using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using ERP.AccesoDatos.Repository;
using Microsoft.EntityFrameworkCore;

namespace ERP.AccesoDatos
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext dbContext;
        internal DbSet<T> dbSet;

        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderyBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProperty);
                }
            }

            if (orderyBy != null)
            {
                return orderyBy(query).ToList();
            }

            return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetByIdGuid(Guid idGuid)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();

        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveById(int id)
        {
            T entityRemove = dbSet.Find(id);
            Remove(entityRemove);
        }
    }
}
