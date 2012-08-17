using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EmployeeSystem.Infrastructure.Repositories.EntityFramework;
using EmployeeSystem.Model;
using EmployeeSystem.Model.IRepository;

namespace EmployeeSystem.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context)
            : base(context)
        {
        }


    }
}
