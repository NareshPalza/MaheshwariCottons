using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Service.IServices
{
    public interface IEmailService
    {
        void SendForgotPasswordMail(string loginID, string password);
    }
}
