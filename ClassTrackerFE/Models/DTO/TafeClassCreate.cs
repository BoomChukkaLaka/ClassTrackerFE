using System;

namespace ClassTrackerFE.Models.DTO
{
    public class TafeClassCreate
    {
        public string TafeClassName { get; set; }
        public string TafeClassLocation { get; set; }
        public DateTime? TafeClassStartDT { get; set; }
        public int? DurationMinutes { get; set; }

        // FK
        public int TeacherId { get; set; }
    }
}
