using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class InsCourse
    {
        public int InsId { get; set; }
        public int CrsId { get; set; }
        public string Evaluation { get; set; }

        public virtual Course Crs { get; set; }
        public virtual Instructor Ins { get; set; }
    }
}
