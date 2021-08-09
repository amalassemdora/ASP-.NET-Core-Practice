using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class Employee1
    {
        public Employee1()
        {
            InverseManager = new HashSet<Employee1>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? ManagerId { get; set; }

        public virtual Employee1 Manager { get; set; }
        public virtual ICollection<Employee1> InverseManager { get; set; }
    }
}
