using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using EmployeeSystem.Infrastructure.DomainBase;

namespace EmployeeSystem.Model
{
    public class Employee : IAggregateRoot
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Company")]
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }
    }
}
