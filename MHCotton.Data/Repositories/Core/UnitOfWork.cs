using MHCotton.Data.Data;
using MHCotton.Data.IRepositories;
using MHCotton.Data.IRepositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Data.Repositories.Core
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MHCottonContext context;
        public IEmployeeRepository Employees { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(MHCottonContext _context)
        {
            context = _context;

            Employees = new EmployeeRepository(context);
            Users = new UserRepository(context);
        }
        public IRepository<T> GetRepository<T>() where T:class
        {
            return new Repository<T>(context);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
