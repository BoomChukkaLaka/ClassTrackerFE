namespace ClassTrackerFE.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }

        // Navigation Property
        public TafeClass TafeClass { get; set; }

        // FK
        public int TafeClassId { get; set; }
    }
}
