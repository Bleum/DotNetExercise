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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
            : base(context)
        {
        }
    }
}
