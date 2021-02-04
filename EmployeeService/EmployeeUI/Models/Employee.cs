using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeUI.Models
{
    public class Employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string empMail { get; set; }
        public string empAddress { get; set; }
        public string empPhone { get; set; }

    }
}