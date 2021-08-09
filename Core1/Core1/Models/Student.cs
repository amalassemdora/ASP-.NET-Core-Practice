using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class Student
    {
        public Student()
        {
            InverseStSuperNavigation = new HashSet<Student>();
        }

        public int StId { get; set; }
        public string StFname { get; set; }
        public string StLname { get; set; }
        public string StAddress { get; set; }
        public int? StAge { get; set; }
        public int? DeptId { get; set; }
        public int? StSuper { get; set; }
        public string Photo { get; set; }
        public string Cv { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual Department Dept { get; set; }
        public virtual Student StSuperNavigation { get; set; }
        public virtual ICollection<Student> InverseStSuperNavigation { get; set; }
    }
}
