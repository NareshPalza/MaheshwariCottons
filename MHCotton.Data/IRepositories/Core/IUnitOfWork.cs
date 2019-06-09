using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Data.IRepositories.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        IEmployeeRepository Employees { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}
