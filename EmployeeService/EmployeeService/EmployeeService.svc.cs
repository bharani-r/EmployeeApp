using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IEmpService
    {
        public int AddEmp(Employee emp)
        {
            EmployeeEntities1 empdb = new EmployeeEntities1();
            EmployeeDetail empdtl = new EmployeeDetail();
            empdtl.EmpId = emp.empId;
            empdtl.EmpName = emp.empName;
            empdtl.EmpMail = emp.empMail;
            empdtl.EmpPhone = emp.empPhone;
            empdb.EmployeeDetails.Add(empdtl);
            int r = empdb.SaveChanges();

            return r;
            
        }

        public int DeleteEmp(int empid)
        {
            EmployeeEntities1 empdb = new EmployeeEntities1();
            EmployeeDetail empdtl = new EmployeeDetail();
            empdtl.EmpId = empid;
            empdb.Entry(empdtl).State = System.Data.Entity.EntityState.Deleted;
            int r = empdb.SaveChanges();

            return r;

        }

        public List<EmployeeDetail> GetAllEmp()
        {
            List<EmployeeDetail> emplist = new List<EmployeeDetail>();
            EmployeeEntities1 empdb = new EmployeeEntities1();

            var emplst = from e in empdb.EmployeeDetails select e;

            foreach (var item in emplst)
            {
                EmployeeDetail em = new EmployeeDetail();
                em.EmpId = item.EmpId;
                em.EmpName = item.EmpName;
                em.EmpMail = item.EmpMail;
                em.EmpPhone = item.EmpPhone;
                emplist.Add(em);

            }
            return emplist;
        }

        public EmployeeDetail GetAllUserById(int empId)
        {
            
            EmployeeEntities1 empdb = new EmployeeEntities1();

            var emplst = from e in empdb.EmployeeDetails  where e.EmpId == empId select e;
            EmployeeDetail employee = new EmployeeDetail();

            foreach (var item in emplst)
            {

                employee.EmpId = item.EmpId;
                employee.EmpName = item.EmpName;
                employee.EmpMail = item.EmpMail;
                employee.EmpPhone = item.EmpPhone;            

            }
            return employee;
        }

        public int UpdateEmp(Employee e)
        {
            EmployeeEntities1 empdb = new EmployeeEntities1();
            EmployeeDetail empdtl = new EmployeeDetail();
            empdtl.EmpId = e.empId;
            empdtl.EmpName = e.empName;
            empdtl.EmpMail = e.empMail;
            empdtl.EmpPhone = e.empPhone;
            empdb.Entry(empdtl).State = System.Data.Entity.EntityState.Modified;
            int r = empdb.SaveChanges();

            return r;
        }
    }
}
