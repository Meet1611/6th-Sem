using first_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace first_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
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
                        cmd.CommandText = "PR_Department_SelectAll";

                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }

                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error loading department data : " + ex.Message;
            }

            return View(dt);
        }

        public IActionResult Delete(int DepID)
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
                        cmd.CommandText = "PR_Department_Delete";
                        cmd.Parameters.AddWithValue("@DepID", DepID);

                        cmd.ExecuteNonQuery();
                    }
                    TempData["SuccessMessage"] = "Department deleted successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting department data : " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddEdit(int? DepID)
        {
            DepartmentModel model = new DepartmentModel();

            if(DepID != null)
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
                            cmd.CommandText = "PR_Department_SelectByID";
                            cmd.Parameters.AddWithValue("@DepID", DepID);

                            SqlDataReader rd = cmd.ExecuteReader();
                            if(rd.Read())
                            {
                                model.DepID = Convert.ToInt32(rd["DepID"]);
                                model.DepartmentName = rd["DepartmentName"].ToString();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    TempData["ErrorMessage"] = "Error loading department : " + ex.Message;
                }
            }
            return View(model);
        }

        public IActionResult Save(DepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddEdit", model);
                }

                string conn = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection sql = new SqlConnection(conn))
                {
                    sql.Open();
                    using (SqlCommand cmd = sql.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (model.DepID == 0)
                        {
                            cmd.CommandText = "PR_Department_Insert";
                        }
                        else
                        {
                            cmd.CommandText = "PR_Department_Update";
                            cmd.Parameters.AddWithValue("@DepID", model.DepID);
                        }

                        cmd.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);

                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = model.DepID == 0 ?
                    "Department added successfully!" :
                    "Department updated successfully!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error saving: " + ex.Message;
            }
            return RedirectToAction("AddEdit");
        }
    }
}
