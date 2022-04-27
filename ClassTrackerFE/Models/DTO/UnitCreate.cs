namespace ClassTrackerFE.Models.DTO
{
    public class UnitCreate
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }

        // FK
        public int TafeClassId { get; set; }
    }
}
