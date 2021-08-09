using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class StudCourse
    {
        public int CrsId { get; set; }
        public int StId { get; set; }
        public int? Grade { get; set; }

        public virtual Course Crs { get; set; }
    }
}
