using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestAPICRUD.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace RestAPICRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("GetEmployeeByID")]
        public Employee Get(int id)
        {
            Employee emp = new Employee();
            string sqlCommand = string.Format("SELECT * from Employee.dbo.EmployeeTable where EmployeeId = {0}", id);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.CommandType = CommandType.Text;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    emp.EmployeeName = reader["EmployeeName"].ToString();
                    emp.ManagerId = Convert.ToInt32(reader["ManagerID"].ToString());
                    emp.EmployeeDepartment = reader["EmployeeDepartment"].ToString();
                }
            }
            return emp;
        }
    }
}