using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? ManagerId { get; set; }
    }
}
