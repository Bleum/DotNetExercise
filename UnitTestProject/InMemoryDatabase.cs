using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeSystem.Model;

namespace UnitTestProject
{
    public class InMemoryDatabase
    {
        public List<Employee> Employees { get; set; }
        public List<Company> Companies { get; set; }

        public InMemoryDatabase()
        {
            Employees = new List<Employee>
            {
                new Employee { ID = 1, Name = "James Shi", Title = "ODC Manager", CompanyID = 1 },
                new Employee { ID = 2, Name = "Mason Wang", Title = "Business Analyst", CompanyID = 1 },
                new Employee { ID = 3, Name = "Yale Yu", Title = "Lead Developer", CompanyID = 1 },
                new Employee { ID = 4, Name = "Steve Ye", Title = "Senior Developer", CompanyID = 1 },
                new Employee { ID = 5, Name = "Lane Wang", Title = "Senior Developer", CompanyID = 1 },
                new Employee { ID = 6, Name = "Lois Xie", Title = "Senior Tester", CompanyID = 1 },
                new Employee { ID = 7, Name = "Carlos Baez", Title = "Development Manager", CompanyID = 2 },
                new Employee { ID = 8, Name = "Shane Wang", Title = "Developer Lead", CompanyID = 2 }
            };

            Companies = new List<Company>
            {
                new Company { ID = 1, Name = "Bleum" },
                new Company { ID = 2, Name = "RBI" }
            };
        }
    }
}
