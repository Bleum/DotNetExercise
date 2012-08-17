using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeSystem.Infrastructure.RepositoryFramework;

namespace EmployeeSystem.Model.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
