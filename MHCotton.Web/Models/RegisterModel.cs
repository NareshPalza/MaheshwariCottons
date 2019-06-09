using MHCotton.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHCotton.Web.Models
{
    public class RegisterModel
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
    }
}