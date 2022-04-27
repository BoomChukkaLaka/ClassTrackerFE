using System;
using System.Collections.Generic;

namespace ClassTrackerFE.Models
{
    public class TafeClass
    {
        public int TafeClassId { get; set; }
        public string TafeClassName { get; set; }
        public string TafeClassLocation { get; set; }
        public DateTime? TafeClassStartDT { get; set; }
        public int? DurationMinutes { get; set; }

        // Navigation Properties
        public ICollection<Unit> Units { get; set; }
        public Teacher Teacher { get; set; }

        // FK
        public int TeacherId { get; set; }
    }
}
