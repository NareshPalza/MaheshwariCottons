using MHCotton.Common.Entities;
using MHCotton.Common.POCOs;
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
    public class EmployeeRepository:Repository<Employees>,IEmployeeRepository
    {
        public EmployeeRepository(MHCottonContext _context):base(_context)
        {

        }
    }
}
