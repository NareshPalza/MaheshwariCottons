using MHCotton.Common.POCOs;
using MHCotton.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MHCotton.Common.Entities;
using MHCotton.Data.IRepositories;
using MHCotton.Data.IRepositories.Core;

namespace MHCotton.Service.Services
{
    public class UserService:Service<Users>,IUserService
    {
        private IUnitOfWork unitOfWork;
        private IEmailService emailService;
        private 
        string hash = "MHCotton";
        public UserService(IUnitOfWork _unitOfWork, IEmailService _emailService):base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
            emailService = _emailService;
        }
        public bool ValidateUser(LoginPOCO loginPOCO)
        {
            var encryptedString = EncryptPassword(loginPOCO.PassWord);
            if (unitOfWork.Users.GetAll().Any(i => i.LoginID == loginPOCO.LoginID && i.Password == encryptedString))
                return true;
            return false;
        }
        public bool RegisterUser(RegisterPOCO registerModel)
        {
            if (!unitOfWork.Users.GetAll().Where(i => i.LoginID == registerModel.Users.LoginID).Any())
            {
                var encryptedString = EncryptPassword(registerModel.Users.Password);
                registerModel.Users.Password = encryptedString;
                unitOfWork.Users.Create(registerModel.Users);
                unitOfWork.Complete();
                registerModel.Employees.UserID = registerModel.Users.ID;
                unitOfWork.Employees.Create(registerModel.Employees);
                unitOfWork.Complete();
                return true;
            }
            return false;
        }
        public string EncryptPassword(string value)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(value);
            using (MD5CryptoServiceProvider mds = new MD5CryptoServiceProvider())
            {
                byte[] keys = mds.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode=CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public string DecryptPassword(string value)
        {
            byte[] data = Convert.FromBase64String(value);
            using (MD5CryptoServiceProvider mds = new MD5CryptoServiceProvider())
            {
                byte[] keys = mds.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        public void ForgotPassword(string loginID)
        {
            var user = unitOfWork.Users.GetAll().Where(i => i.LoginID == loginID).FirstOrDefault();
            var passwordGenerated = this.RandomPassword(12);
            user.Password = EncryptPassword(passwordGenerated);
            unitOfWork.Complete();
            if (user != null)
            {
                emailService.SendForgotPasswordMail(user.LoginID, passwordGenerated);
            }
        }
        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(12, true));
            return builder.ToString();
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
