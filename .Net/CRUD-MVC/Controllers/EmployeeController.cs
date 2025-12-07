using first_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace first_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IActionResult Index(string EmpName = "", decimal Salary = 0, DateTime JoiningDate = new DateTime(), string City = "", int DepID = 0)
        {
            // load department dropdown
            DepartmentDropdown(DepID);

            DataTable dt = new DataTable();

            try
            {
                string connStr = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_Employee_Search";

                        cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = EmpName ?? "";
                        cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = Salary;
                        cmd.Parameters.Add("@JoiningDate", SqlDbType.DateTime).Value = (JoiningDate == DateTime.MinValue) ? (object)DBNull.Value : JoiningDate;
                        cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = City ?? "";
                        cmd.Parameters.Add("@DepID", SqlDbType.Int).Value = DepID;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error loading employee data : " + ex.Message;
            }

            // Preserve Serach value
            ViewBag.EmpName = EmpName;
            ViewBag.Salary = Salary;
            ViewBag.JoiningDate = JoiningDate;
            ViewBag.City = City;
            ViewBag.DepID = DepID;

            return View(dt);
        }

        public IActionResult Delete(int EmpID)
        {
            try
            {
                string connStr = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_Employee_Delete";
                        cmd.Parameters.AddWithValue("@EmpID", EmpID);

                        cmd.ExecuteNonQuery();
                    }
                    TempData["SuccessMessage"] = "Employee deleted successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting employee data : " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddEdit(int? EmpID)
        {
            EmployeeModel model = new EmployeeModel();

            // Load Department Dropdown
            DepartmentDropdown();

            if (EmpID != null)
            {
                try
                {
                    string connStr = _configuration.GetConnectionString("DefaultConnection");

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "PR_Employee_SelectByID";
                            cmd.Parameters.AddWithValue("@EmpID", EmpID);

                            SqlDataReader rd = cmd.ExecuteReader();
                            if (rd.Read())
                            {
                                model.EmpID = Convert.ToInt32(rd["EmpID"]);
                                model.EmpName = rd["EmpName"].ToString();
                                model.Salary = Convert.ToDecimal(rd["Salary"]);
                                model.City = rd["City"].ToString();
                                model.JoiningDate = Convert.ToDateTime(rd["JoiningDate"]);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    TempData["ErrorMessage"] = "Error loading Employees : " + ex.Message;
                }
            }
            return View("AddEdit", model);
        }

        private void DepartmentDropdown(int SelectedDepID = 0)
        {
            List<DepartmentDropdownModel> departmentList = new List<DepartmentDropdownModel>();

            string connStr = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection sql = new SqlConnection(connStr))
            {
                sql.Open();
                using (SqlCommand cmd = sql.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Department_SelectAll";

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        departmentList.Add(new DepartmentDropdownModel
                        {
                            DepID = Convert.ToInt32(rd["DepID"]),
                            DepartmentName = rd["DepartmentName"].ToString()
                        });

                    }
                }
            }
            ViewBag.DepartmentList = departmentList;
            ViewBag.SelectedDeptID = SelectedDepID;
        }

        [HttpPost]
        public IActionResult Save(EmployeeModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                   DepartmentDropdown();
                   return View("AddEdit", model);
                }

                string conn = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection sql = new SqlConnection(conn))
                {
                    sql.Open();
                    using (SqlCommand cmd = sql.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (model.EmpID == 0)
                        {
                            cmd.CommandText = "PR_Employee_Insert";
                        }
                        else
                        {
                            cmd.CommandText = "PR_Employee_Update";
                            cmd.Parameters.AddWithValue("@EmpID", model.EmpID);
                        }

                        cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                        cmd.Parameters.AddWithValue("@Salary", model.Salary);
                        cmd.Parameters.AddWithValue("@City", model.City);
                        cmd.Parameters.AddWithValue("@JoiningDate", model.JoiningDate);
                        cmd.Parameters.AddWithValue("@DeptID", model.DepID);

                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = model.EmpID == 0 ?
                    "Employee added successfully!" :
                    "Employee updated successfully!";

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Error saving: " + ex.Message;
                return RedirectToAction("AddEdit");
            }
        }
    }
}
