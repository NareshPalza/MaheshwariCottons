using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Service.IServices.Core
{
    public interface ISowServiceLocator
    {
        IService<T> GetService<T>() where T : class;
        IUserService Users { get; }
        int Complete();
    }
}
