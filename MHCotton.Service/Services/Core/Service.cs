using MHCotton.Data.IRepositories;
using MHCotton.Data.IRepositories.Core;
using MHCotton.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Service.Services
{
    public class Service<T>:IService<T> where T:class
    {
        private IUnitOfWork unitOfWork;
        public Service(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<T> GetAll()
        {
            return unitOfWork.GetRepository<T>().GetAll();
        }
        public T GetEntityByID(int ID)
        {
            return unitOfWork.GetRepository<T>().GetEntityByID(ID);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return unitOfWork.GetRepository<T>().Find(predicate);
        }

        public void Create(T entity)
        {
            unitOfWork.GetRepository<T>().Create(entity);
        }
        public void Delete(T entity)
        {
            unitOfWork.GetRepository<T>().Delete(entity);
        }
    }
}
