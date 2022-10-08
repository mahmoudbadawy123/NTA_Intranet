using DataAccessLayer.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Class
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        //https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
        DbSet<TEntity> dbSet;
        IApplicationContext db;
        public Repository(IApplicationContext dbContext)
        {
            db = dbContext;
            dbSet = db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            entity = dbSet.Add(entity).Entity;
            return entity;
        }
        public List<TEntity> AddRange(List<TEntity> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i] = dbSet.Add(list[i]).Entity;
            return list;
        }

        public TEntity Find(params object[] predicate)
        {
            return dbSet.Find(predicate);
        }
        public TResult Max<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return dbSet.Max(selector);
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }
        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.First(predicate);
        }
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }
        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
        public TEntity Remove(TEntity entity)
        {
            entity = dbSet.Remove(entity).Entity;
            return entity;
        }

        public List<TEntity> RemoveRange(List<TEntity> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i] = dbSet.Remove(list[i]).Entity;
            return list;
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Count(predicate);
        }

     
    }
}
