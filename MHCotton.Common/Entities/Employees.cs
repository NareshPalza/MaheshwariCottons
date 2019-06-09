using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Common.Entities
{
    public class Employees
    {
        public Employees(int id, string firstName, string middleName, string lastName, string emailID, int userID)
        {
            ID = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EmailID = emailID;
            UserID = userID;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public int UserID { get; set; }
        [NotMapped]
        public Users Users { get; set; }
    }
}
