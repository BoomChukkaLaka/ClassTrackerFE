using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassTrackerFE.Models
{
    public class Teacher
    {
        [Display(Name = "Id")]
        public int TeacherId { get; set; }
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
        [Display(Name = "Email")]
        public string TeacherEmail { get; set; }
        [Display(Name = "Phone Number")]
        public string TeacherPhone { get; set; }

        // Navigation Property
        public ICollection<TafeClass> TafeClasses { get; set; }
    }
}
