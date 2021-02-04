using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Models
{
    public class EmployeeController : Controller
    {
        EmployeeService.EmpServiceClient emp = new EmployeeService.EmpServiceClient();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> lst = new List<Employee>();

            var list = emp.GetAllEmp();
            foreach (var item in list)
            {
                Employee e = new Employee();
                e.empId = item.EmpId;
                e.empName = item.EmpName;
                e.empMail = item.EmpMail;
                e.empPhone = item.EmpPhone;
                lst.Add(e);
            }
            return View(lst);
        }

        
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        // GET: Employee/Create
        public ActionResult Add(Employee em)
        {
            EmployeeService.Employee e = new EmployeeService.Employee();
            e.empId = em.empId;
            e.empName = em.empName;
            e.empMail = em.empMail;
            e.empPhone = em.empPhone;

            emp.AddEmp(e);
            ViewBag.Message = String.Format("Employee "+ e.empId+" created successully");

            return RedirectToAction("Index","Employee");
        }

       
        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            int r = emp.DeleteEmp(id);
            if (r>0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var lst = emp.GetAllUserById(id);
            Employee e = new Employee();
            e.empId = lst.EmpId;
            e.empName = lst.EmpName;
            e.empMail = lst.EmpMail;
            e.empPhone = lst.EmpPhone;

            return View(e);

         }
        [HttpPost]
        public ActionResult Edit(Employee em)
        {
           
            EmployeeService.Employee e = new EmployeeService.Employee();
            e.empId = em.empId;
            e.empName = em.empName;
            e.empMail = em.empMail;
            e.empPhone = em.empPhone;

            int r = emp.UpdateEmp(e);
                if (r > 0)
            {
                ViewBag.Message = String.Format("Employee " + e.empId + " Updated successfully");
                return RedirectToAction("Index", "Employee");
                
            }
            ViewBag.Message = String.Format("Employee " + e.empId + " was not updated");

            return View();

        }
    }
}
