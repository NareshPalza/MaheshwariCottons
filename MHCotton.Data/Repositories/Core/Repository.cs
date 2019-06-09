using MHCotton.Data.Data;
using MHCotton.Data.IRepositories;
using MHCotton.Data.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Data.Repositories.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> dbSet;
        protected readonly MHCottonContext dbEntities;
        public Repository(MHCottonContext context)
        {
            dbEntities = context;
            dbSet = dbEntities.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public T GetEntityByID(int ID)
        {
            return dbSet.Find(ID);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }


        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
