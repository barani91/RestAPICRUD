using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPICRUD.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName {get;set;}
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string EmployeeDepartment { get; set; }
    }
}