using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int empId { get; set; }
        [DataMember]
        public string empName { get; set; }
        [DataMember]
        public string empPhone { get; set; }
        [DataMember]
        public string empMail { get; set; }
    }
}