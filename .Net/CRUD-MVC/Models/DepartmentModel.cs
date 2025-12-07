using System.ComponentModel.DataAnnotations;

namespace first_MVC.Models
{
    public class DepartmentModel
    {
        public int DepID { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100, ErrorMessage = "Department Name cannot exceed 100 characters")]
        public string DepartmentName { get; set; }
    }
}
