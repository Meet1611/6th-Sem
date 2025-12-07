using System.ComponentModel.DataAnnotations;

namespace first_MVC.Models
{
    public class EmployeeModel
    {
        public int EmpID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, ErrorMessage = "Employee Name cannot exceed 100 characters")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Employee Salary is Required")]
        public Decimal Salary { get; set; }

        [Required(ErrorMessage = "EMployee Joining Date is Required")]
        public DateTime JoiningDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Employee City cannot exceed 100 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Select a Department")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Department")]
        public int DepID { get; set; }
    }

    public class DepartmentDropdownModel
    {
        public int DepID { get; set; }
        public string DepartmentName { get; set; }
    }
}
