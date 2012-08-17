using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeSystem.Infrastructure.RepositoryFramework;
using EmployeeSystem.Infrastructure.Utility;
using EmployeeSystem.Model;
using EmployeeSystem.Model.IRepository;
using PagedList;
using PagedList.Mvc;

namespace EmployeeSystem.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;
        private ICompanyRepository companyRepository;

        public EmployeeController()
        {
            employeeRepository = RepositoryFactory.GetRepository<IEmployeeRepository, Employee>();
            companyRepository = RepositoryFactory.GetRepository<ICompanyRepository, Company>();
        }

        public EmployeeController(IEmployeeRepository er, ICompanyRepository cr)
        {
            employeeRepository = er;
            companyRepository = cr;
        }

        //
        // GET: /Employee/

        public ViewResult Index(string property, string value, int pageNumber = 1, int pageSize = 5)
        {
            IQueryable<Employee> employees;
            if (!string.IsNullOrEmpty(property) && !string.IsNullOrEmpty(value))
                employees = employeeRepository.FindBy(property, value).OrderBy(e => e.ID);
            else
                employees = employeeRepository.FindAll().OrderBy(e => e.ID);
            
            IPagedList<Employee> pagedList = employees.ToPagedList(pageNumber, pageSize);

            ViewBag.Property = new List<SelectListItem>{
                new SelectListItem { Text = "Name", Value = "Name" },
                new SelectListItem { Text = "Title", Value = "Title" },
                new SelectListItem { Text = "Company", Value = "Company.Name" }
            };
            
            return View(pagedList);
        }

        //
        // GET: /Employee/Edit/5
 
        public ActionResult Edit(int id)
        {
            Employee employee = employeeRepository.FindBy(id);
            ViewBag.CompanyID = new SelectList(companyRepository.FindAll(), "ID", "Name", employee.CompanyID);
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Update(employee);
                employeeRepository.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(companyRepository.FindAll(), "ID", "Name", employee.CompanyID);
            return View(employee);
        }
    }
}