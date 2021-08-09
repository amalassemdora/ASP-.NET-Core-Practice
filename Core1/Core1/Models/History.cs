using System;
using System.Collections.Generic;

#nullable disable

namespace Core1.Models
{
    public partial class History
    {
        public string User { get; set; }
        public DateTime? Date { get; set; }
        public int? Old { get; set; }
        public int? New { get; set; }
    }
}
