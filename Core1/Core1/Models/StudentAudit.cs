﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class StudentAudit
    {
        public string ServerUserName { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
    }
}
