using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using EmployeeSystem.Infrastructure.DomainBase;

namespace EmployeeSystem.Model
{
    public class Company : IAggregateRoot
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
