using MHCotton.Common.Entities;
using MHCotton.Data.Data;
using MHCotton.Data.Repositories;
using MHCotton.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHCotton.Data.Repositories.Core;

namespace MHCotton.Data.Repositories
{
    public class UserRepository:Repository<Users>,IUserRepository
    {
        public UserRepository(MHCottonContext _context):base(_context)
        {

        }
    }
}
