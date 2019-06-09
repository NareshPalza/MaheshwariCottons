using MHCotton.Common.Entities;
using MHCotton.Common.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Service.IServices
{
    public interface IUserService:IService<Users>
    {
        bool ValidateUser(LoginPOCO loginPOCO);
        bool RegisterUser(RegisterPOCO registerModel);
        void ForgotPassword(string loginID);
    }
}
