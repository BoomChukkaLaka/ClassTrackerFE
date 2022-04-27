using System.ComponentModel.DataAnnotations;

namespace ClassTrackerFE.Models.DTO
{
    public class TeacherCreate
    {
        [Display(Name = "Teacher Name")]
        [Required(ErrorMessage = "Name Required")]
        [StringLength(50)]
        public string TeacherName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string TeacherEmail { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required")]
        public string TeacherPhone { get; set; }
    }
}
