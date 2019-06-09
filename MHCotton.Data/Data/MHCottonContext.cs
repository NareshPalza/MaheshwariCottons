using MHCotton.Common.Entities;
using MHCotton.Common.POCOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Data.Data
{
    public class MHCottonContext : DbContext
    {
        public MHCottonContext() : base("name=MHCottonContext")
        {
            Database.SetInitializer<MHCottonContext>(new CreateDatabaseIfNotExists<MHCottonContext>());
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
