using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Common.Entities
{
    public class Users
    {
        public Users()
        {

        }
        public Users(int id, string loginID, string password)
        {
            ID = id;
            LoginID = loginID;
            Password = password;
        }
        public int ID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
    }
}
