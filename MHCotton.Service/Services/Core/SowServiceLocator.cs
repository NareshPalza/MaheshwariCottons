using MHCotton.Data.IRepositories.Core;
using MHCotton.Service.IServices;
using MHCotton.Service.IServices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Service.Services.Core
{
    public class SowServiceLocator:ISowServiceLocator
    {
        private IUnitOfWork unitOfWork;
        public IUserService userService;
        public SowServiceLocator(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }
        
    }
}
