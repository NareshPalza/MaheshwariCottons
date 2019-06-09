using MHCotton.Common;
using MHCotton.Common.Entities;
using MHCotton.Common.POCOs;
using MHCotton.Service.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Service.Services
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
        }
        public void SendForgotPasswordMail(string loginID, string password)
        {
            var email = new Dictionary<string, string>()
            {
                { "UserName", loginID},
                { "Password", password}
            };

            SMTPMail.GetEmailContent("ForgotPassword.xslt", email, "nareshpalza@gmail.com");
        }
    }
}
