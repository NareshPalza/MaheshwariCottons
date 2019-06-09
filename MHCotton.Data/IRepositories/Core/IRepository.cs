using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Data.IRepositories.Core
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetEntityByID(int ID);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Create(T entity);
        void Delete(T entity);
    }
}
